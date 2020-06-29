using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.AccountModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression("^.+@.+$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter word")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        //[RegularExpression(@"/^0(1\d{9}|9\d{8})$/")]
        public string Phone { get; set; }
    }
}