using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    public class ApartmentReview
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
        [Range(0, 5)]
        public int Starts { get; set; }
    }
}
