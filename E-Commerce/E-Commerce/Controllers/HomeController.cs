using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            List<Product> products = db.Products.Take(16).ToList();

            List<Product> featureProducts = db.Products.Take(10).ToList();

            ViewBag.featureProducts = featureProducts;

            return View(products);
        }

        //Category

        public ActionResult loadCategory()
        {
            List<Category> category = db.Categories.Take(6).ToList();
            return PartialView(category);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}