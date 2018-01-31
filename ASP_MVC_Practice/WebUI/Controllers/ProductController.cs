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
            product.Id = Guid.NewGuid().ToString();
            products.Add(product);
            commit();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProductPage(string id)
        {
            Product productToDelete = products.Find(n => n.Id == id);
            return View(productToDelete);
        }
        public ActionResult DeleteProduct(string id)
        {
            Product productToDelete = products.Find(n => n.Id == id);
            products.Remove(productToDelete);
            commit();
            //return RedirectToAction("Index");
            return View();
        }
        public void commit()
        {
            Cache["products"] = products;
        }
	}
}