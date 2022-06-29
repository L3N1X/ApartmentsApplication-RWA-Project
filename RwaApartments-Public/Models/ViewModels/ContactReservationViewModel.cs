using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RwaApartments_Public.Models.ViewModels
{
    public class ContactReservationViewModel
    {
        public User User { get; set; }
        public string FirstName { get; set; }
        public  int ApartmentId { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
    }
}