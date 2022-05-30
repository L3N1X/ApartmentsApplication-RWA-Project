using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    public class ApartmentPicture
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int ApartmentId { get; set; }
        public string Path { get; set; }
        public string Base64Content { get; set; }
        public string Name { get; set; }
        public bool IsRepresentative{ get; set; }
    }
}
