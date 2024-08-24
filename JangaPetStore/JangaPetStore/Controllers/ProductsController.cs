using Microsoft.AspNetCore.Mvc;
using JangaPetStore.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JangaPetStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _uploadsFolder;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_uploadsFolder))
            {
                Directory.CreateDirectory(_uploadsFolder);
            }
        }

        public IActionResult Index(int categoryId)
        {
            var products = _context.Products
                                   .Where(p => p.CategoryId == categoryId)
                                   .Include(p => p.Category)
                                   .ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products
                                  .Include(p => p.Category)
                                  .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddProduct(Product product, IFormFile? ImageFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ImageFile != null && ImageFile.Length > 0)
        //        {
        //            // Generate a unique file name to avoid conflicts
        //            var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(ImageFile.FileName);
        //            var filePath = Path.Combine(_uploadsFolder, fileName);

        //            try
        //            {
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    await ImageFile.CopyToAsync(stream);
        //                }

        //                // Set the ImageUrl property
        //                product.ImageUrl = $"/uploads/{fileName}";
        //            }
        //            catch (Exception ex)
        //            {
        //                ModelState.AddModelError("", $"Error saving file: {ex.Message}");
        //                return View(product);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ImageFile", "Please select an image.");
        //            return View(product);
        //        }

        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

    }
}
