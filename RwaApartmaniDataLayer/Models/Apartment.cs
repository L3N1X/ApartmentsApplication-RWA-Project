using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int OwnerId { get; set; } //Add reference field
        public int TypeId { get; set; } //Add reference field
        public int StatusId { get; set; } //Add reference field
        public int CityId { get; set; } //Add reference field
        public string Address { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public IList<ApartmentPicture> Pictures { get; set; }
        public int PicturesCount { get => Pictures.Count; } //dangerous right now
        public IList<Tag> Tags { get; set; }
        public ApartmentStatus Status { get; set; }
        public City City { get; set; } = new City();
    }
}
