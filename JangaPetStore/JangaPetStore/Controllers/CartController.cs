
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JangaPetStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace JangaPetStore.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                     .ThenInclude(ci => ci.Product)
                                     .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { CartItems = new List<CartItem>() };
            }

            return View(cart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                ModelState.AddModelError("", "Invalid quantity.");
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                     .ThenInclude(ci => ci.Product)
                                     .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { UserId = user.Id };
                _context.Carts.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Cart = cart
                };
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                     .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == id);
                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                     .ThenInclude(ci => ci.Product)
                                     .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index");
            }

            // Create order from cart
            var order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerName = user.UserName,
                CustomerEmail = user.Email,
                ShippingAddress = "User Address", // Update as needed
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

            return View(order);
        }
    }
}
