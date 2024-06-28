using Ecommerce1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Linq;



namespace Ecommerce10.Controllers
{
    public class EcommerceController : Controller
    {
        EcommerceContext db;
        public EcommerceController(EcommerceContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {

            return View();
        }
       
        public IActionResult books(int id = 5)
        {
            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        public IActionResult electronic(int id = 2)
        {
            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        public IActionResult fashion(int id = 1)
        {
            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        public IActionResult jewellery(int id = 4)
        {
            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        public IActionResult software(int id = 3)
        {
            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        public IActionResult watch(int id = 6)
        {

            var prod = db.Products.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }
        

        private List<Product> cartItems = new List<Product>(); // List to store selected products
        [Authorize("UserAccess")]
        // GET: Cart/AddToCart
        public IActionResult AddToCart(int productId)
        {
            // Retrieve the product based on the productId (from your data source)
            Product product = GetProductById(productId);

            if (product != null)
            {
                // Add the selected product to the cartItems list
                cartItems.Add(product);
            }

            return RedirectToAction("Cart"); // Redirect to the cart view
        }

        // GET: Cart/Cart
        public IActionResult Cart()
        {
            return View(cartItems);
        }

        // Helper method to retrieve the product by ID (replace with your own implementation)
        private Product GetProductById(int productId)
		{
			// Retrieve the product from the database or any other data source based on the product ID
			// Replace this code with your own implementation to fetch the product from your data source
			// Example:
			Product product = db.Products.FirstOrDefault(p => p.ProductId == productId);

			return product;
		}
	}


}

