using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.ViewModels
{
    public class ViewApartmentViewModel
    {
        public int ApartmentId { get; set; } 
        public string UserId { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public Apartment Apartment { get; set; }
        public bool ShowReviewForm { get; set; }
    }
}