using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using WebUI.Models;
namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        
        ObjectCache Cache = MemoryCache.Default;
        List<Product> products;

        public ProductController()  {
            products = Cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
            products.Add(new Product() { Id = 101, Name = "PlayStation", Category = "Toy", Price = 1000 });
            Cache["products"] = products;
        }
        public ActionResult Index()
        {
            return View(products);
        }
	}
}