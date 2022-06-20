using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.ViewModels
{
    public class ApartmentsBrowserViewModel
    {
        public IEnumerable<Apartment> Apartments { get; set; }
    }
}