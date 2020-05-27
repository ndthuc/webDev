using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.AccountModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please enter your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}