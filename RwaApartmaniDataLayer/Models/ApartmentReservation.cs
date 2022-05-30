using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    public class ApartmentReservation
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set;} 
        public int ApartmentId { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        
    }
}
