using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace batteryfilms.MVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}