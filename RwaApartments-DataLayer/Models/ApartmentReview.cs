using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    [Serializable]
    public class ApartmentReview
    {
        private string details;

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Details
        {
            get
            {
                if(details == null)
                    return string.Empty;
                return details;
            }
            set => details = value; 
        }

        [Range(0, 5)]
        public int Stars { get; set; }
        public User User { get; set; }
        public Apartment Apartment { get; set; }
    }
}
