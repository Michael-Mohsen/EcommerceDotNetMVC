using Ecommerce1.Models;
using Ecommerce10.Data;
using Ecommerce10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Ecommerce10.Controllers
{
	public class HomeController : Controller
	{

		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//    _logger = logger;
		//}

		EcommerceContext db;
		ApplicationDbContext db1;
		public HomeController(EcommerceContext context, ApplicationDbContext dbContext)
		{
			db = context;
			db1 = dbContext;
		}

		public IActionResult Index()
		{
			var Name = HttpContext.Session.GetString("Name");
			if(string.IsNullOrEmpty(Name) )
			{
				//return RedirectToAction("Register", "Account");
			}
			return View("/Views/Home/Index.cshtml");
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


		[Authorize("UserAccess")]
		public IActionResult cart()
		{

			return View();
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


        //     [HttpPost]
        //     [ValidateAntiForgeryToken]
        //     public async Task<IActionResult> AddToCart([Bind(" ProductId,Quantaty,Price")] CartItem cartitems,
        //int ProductId, string Name, decimal? Price)
        //     {

        //         if (!String.IsNullOrEmpty(Name) && Price != null)
        //         {
        //	cartitems.ProductId = ProductId;
        //	cartitems.Name = Name;
        //	cartitems.Price = Price;

        //             db.Add(cartitems);
        //             await db.SaveChangesAsync();

        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
    }


}
