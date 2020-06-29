using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.CartModels
{
    public class CartItem
    {
        public string ProductImg { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}