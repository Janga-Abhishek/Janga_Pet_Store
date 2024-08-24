using Microsoft.AspNetCore.Mvc;
using JangaPetStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JangaPetStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _uploadsFolder;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_uploadsFolder))
            {
                Directory.CreateDirectory(_uploadsFolder);
            }
        }


        [HttpGet]
        public IActionResult Products()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Generate a unique file name to avoid conflicts
                    var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(_uploadsFolder, fileName);

                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        // Set the ImageUrl property
                        product.ImageUrl = $"/uploads/{fileName}";
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Error saving file: {ex.Message}");
                        return View(product);
                    }
                }
                else
                {
                    product.ImageUrl = "/uploads/logo.png";

                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");

            return View(product);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Load categories for the dropdown
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(Product product, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Handle image file upload
                    var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                    try
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        // Update the ImageUrl property with the new image
                        product.ImageUrl = $"/uploads/{fileName}";
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Error saving file: {ex.Message}");
                        ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
                        return View(product);
                    }
                }
                else
                {
                    // Keep the current image URL if no new image is selected
                    var existingProduct = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == product.ProductId);
                    if (existingProduct != null)
                    {
                        product.ImageUrl = existingProduct.ImageUrl;
                    }
                }

                // Update the product details
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Products");
            }

            // Reload categories in case of validation error
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }


        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Products");
        }
    }
}
