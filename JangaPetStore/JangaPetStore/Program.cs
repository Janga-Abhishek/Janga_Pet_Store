using JangaPetStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add authentication and authorization services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Path for login page
        options.LogoutPath = "/Account/Logout"; // Path for logout
        options.AccessDeniedPath = "/Account/AccessDenied"; // Path for access denied
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    // Seed roles and users if they do not exist
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Seed roles
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole { Name = "User", NormalizedName = "USER" });
    }

    // Seed users
    var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    var user1 = await userManager.FindByEmailAsync("user1@example.com");
    if (user1 == null)
    {
        user1 = new IdentityUser
        {
            UserName = "user1@example.com",
            Email = "user1@example.com",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user1, "Password1!");
        await userManager.AddToRoleAsync(user1, "User");
    }

    var user2 = await userManager.FindByEmailAsync("user2@example.com");
    if (user2 == null)
    {
        user2 = new IdentityUser
        {
            UserName = "user2@example.com",
            Email = "user2@example.com",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user2, "Password2!");
        await userManager.AddToRoleAsync(user2, "User");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
