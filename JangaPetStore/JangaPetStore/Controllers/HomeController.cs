using Microsoft.AspNetCore.Mvc;
using JangaPetStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace JangaPetStore.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = _context.Categories.Include(c => c.Products).ToList();
            var user = await _userManager.GetUserAsync(User);

            // Count previous orders for the user
            var orderCount = await _context.Orders
                                           .Where(o => o.CustomerEmail == user.Email)
                                           .CountAsync();

            ViewBag.OrderCount = orderCount;

            return View(categories);
        }

        public async Task<IActionResult> PreviousOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _context.Orders
                                       .Include(o => o.OrderItems)
                                       .ThenInclude(oi => oi.Product)
                                       .Where(o => o.CustomerEmail == user.Email)
                                       .ToListAsync();

            return View(orders);
        }
    }
}
