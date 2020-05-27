using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.AccountModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^.+@.+$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"/^0(1\d{9}|9\d{8})$/")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        //[RegularExpression(@"^\+?(?:0|84)(?:\d){9}$")]
        public string Phone { get; set; }
    }
}