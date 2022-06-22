using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.ViewModels
{
    public class ApartmentListViewModel
    {
        public IEnumerable<Apartment> Apartments { get; set; }
    }
}