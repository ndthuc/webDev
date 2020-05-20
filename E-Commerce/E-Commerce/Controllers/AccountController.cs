using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using E_Commerce.Models;
using E_Commerce.Models.AccountModels;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        Model1 db = new Model1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel newUser)
        {
            AccountManage manage = new AccountManage();
            if (manage.CheckUserName(newUser.UserName)
                && manage.CheckEmail(newUser.Email)
                && manage.CheckPhonenumber(newUser.Phone))
            {
                User user = new User
                {
                    Account = newUser.UserName,
                    Email = newUser.Email,
                    PhoneNumber = newUser.Phone,
                    Password = manage.EncryptedPassword(newUser.Password),
                    TypeUser = "normal"
                };

                db.Users.Add(user);
                db.SaveChanges();

            }
            else
            {
                return View("Fail");
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            AccountManage manage = new AccountManage();
            if (manage.CheckUserLogin(login))
            {
                return View("MyProfile");
            }
            else
            {
                return View("Fail");
            }

        }

    }
}