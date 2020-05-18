using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        Model1 db = new Model1();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewListProduct(int id)
        {
            IEnumerable<Product> products = from pro in db.Products
                                            where pro.CategoryID == id
                                            select pro;

            return View(products);
        }
    }
}