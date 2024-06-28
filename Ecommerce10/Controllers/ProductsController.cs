using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce1.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Ecommerce10.Controllers
{
	[Authorize("AdminAccess")]
	public class ProductsController : Controller
    {
		private readonly IWebHostEnvironment _environment;
        private readonly EcommerceContext _context;
       
        public ProductsController(EcommerceContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Products.Include(p => p.Category);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.



       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Price,Quantaty,CategoryId")] Product Product, IFormFile img_file)
        {
            // to create Images folder in the project Path.
            string path = Path.Combine(_environment.WebRootPath, "Ecommroot/images"); // wwwroot/Ecommroot/
			if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    // ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                    Product.Image = "/Ecommroot/images/" + img_file.FileName;
                }
            }
			else
			{
				Product.Image = "/Ecommroot/images/coolingpad.jpg"; // to save the default image path in database.
			}
			try
			{
				_context.Add(Product);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex) { ViewBag.exc = ex.Message; }


			return View();
        }







        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Price,Quantaty,CategoryId")] Product Product, IFormFile img_file)
		{
			// to create Images folder in the project Path.
			string path = Path.Combine(_environment.WebRootPath, "Ecommroot/images"); // wwwroot/Ecommroot/
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (img_file != null)
			{
				path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await img_file.CopyToAsync(stream);
					// ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
					Product.Image = "/Ecommroot/images/" + img_file.FileName;
				}
			}
			else
			{
				Product.Image = "/Ecommroot/images/coolingpad.jpg"; // to save the default image path in database.
			}
			try
			{
				_context.Update(Product);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex) { ViewBag.exc = ex.Message; }


			return View();
		}

		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'EcommerceContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
