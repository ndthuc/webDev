using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        Model1 db = new Model1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Detail(int id)
        //{
        //    Product product = db.Products.Where(pro => pro.ProductID == id).SingleOrDefault();
        //    return View(product);
        //}

        public ActionResult Detail()
        {
            return View();
        }

    }
}