using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JangaPetStore.Models; 
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                return RedirectToAction("Products", "Admin"); 
            }
            else if (roles.Contains("User"))
            {
                return RedirectToAction("Index", "Home"); 
            }
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Username not found.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                return RedirectToAction("Products", "Admin");
            }
            else if (roles.Contains("User"))
            {
                return RedirectToAction("Index", "Home");
            }
        }
        else if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "This account has been locked out. Please try again later.");
        }
        else if (result.IsNotAllowed)
        {
            ModelState.AddModelError(string.Empty, "You are not allowed to log in.");
        }
        else if (result.RequiresTwoFactor)
        {
            // Handle two-factor authentication if needed
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid password.");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Login", "Account");
    }
}
