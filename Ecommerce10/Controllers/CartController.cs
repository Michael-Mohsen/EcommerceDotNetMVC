using Ecommerce1.Models;
using Ecommerce10.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce10.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommerceContext _context;

        public CartController(EcommerceContext context)
        {
            _context = context;

		}
		
        public IActionResult books()
        {
            List<Product>  products = _context.Products.ToList();
            return View(products);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task <IActionResult> Create([Bind(" ProductId,Quantaty,Price")] CartItem cartitems){

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(cartitems);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cartitems);
        //}
        
        public IActionResult AddToCart(int ProductId)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            //List<Product> products = _context.Products.ToList();

            CartItem? item1 = cart.FirstOrDefault(i => i.ProductId == ProductId);

            if (item1 != null)
            {


            }
            else
            {
                Product? p1 = _context.Products.FirstOrDefault(x => x.ProductId == ProductId);
                CartItem? newItem = new CartItem
                {
                    ProductId = p1?.ProductId,
                    Quantity = p1?.Quantaty,
                    Price = p1?.Price,

                };
                cart.Add(newItem);
            }
            HttpContext.Session.Set("cart", cart);
            _context.SaveChanges();
            return RedirectToAction("Index", "Ecommerce");
        }

        public IActionResult Cart()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();

            return View(cart);
        }


        public IActionResult RemoveFromCart(int ProductId)
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem? CItem = cart.Find(i => i.ProductId == ProductId);
            cart.Remove(CItem);
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("Cart");
        }

    }
}
