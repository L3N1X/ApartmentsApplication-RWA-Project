using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number can only contain digits")]
        [Required(ErrorMessage = "Please specify your phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please specify your address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm specified password")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}