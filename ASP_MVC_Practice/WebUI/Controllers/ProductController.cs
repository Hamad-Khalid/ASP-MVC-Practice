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
        }
        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult AddProductPage()
        {
            return View();
        }
        public ActionResult AddProduct(Product product)
        {
            products.Add(product);
            comit();
            return RedirectToAction("Index");
        }
        public void comit()
        {
            Cache["products"] = products;
        }
	}
}