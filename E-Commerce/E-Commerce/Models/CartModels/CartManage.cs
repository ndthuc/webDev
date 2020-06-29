using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.CartModels
{
    public class CartManage
    {
        Model1 db = new Model1();
        public bool CheckUserLoginAvailable()
        {
            return false;
        }

        public bool CheckProductIsAlready(int id)
        {
            
            return false;
        }
    }
}