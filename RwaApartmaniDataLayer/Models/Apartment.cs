using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Models
{
    [Serializable]
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
        public string NameEng { get; set; }
        public decimal Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public IList<ApartmentPicture> Pictures { get; set; }
        public ApartmentPicture RepresentativePicture
        {
            get
            {
                var representativePicture = Pictures.FirstOrDefault(picture => picture.IsRepresentative);
                if (representativePicture is null)
                    representativePicture = Pictures[0];
                return representativePicture;
            }
        }
        public int TotalSpaces
        {
            get
            {
                return MaxAdults + MaxChildren;
            }
        }
        public int PicturesCount { get => Pictures.Count; } 
        public string CityName { get => this.City.Name; } 
        public IList<Tag> Tags { get; set; }
        public ApartmentStatus Status { get; set; }
        public City City { get; set; } = new City();
        public string PriceString { get => String.Format("{0:0.00}", Price) + "€"; }

        public static Comparison<Apartment> PriceLowToHighComparison = ((left, right) => left.Price.CompareTo(right.Price));
        public static Comparison<Apartment> PriceHighToLowComparison = ((left, right) => -left.Price.CompareTo(right.Price));
        public static Comparison<Apartment> TotalRoomsLowToHighComparison = ((left, right) => left.TotalRooms.CompareTo(right.TotalRooms));
        public static Comparison<Apartment> TotalRoomsHighToLowComparison = ((left, right) => -left.TotalRooms.CompareTo(right.TotalRooms));
        public static Comparison<Apartment> TotalSpaceLowToHighComparison = ((left, right) => (left.MaxAdults + left.MaxChildren).CompareTo(right.MaxAdults + right.MaxChildren));
        public static Comparison<Apartment> TotalSpaceHighToLowComparison = ((left, right) => -(left.MaxAdults + left.MaxChildren).CompareTo(right.MaxAdults + right.MaxChildren));

    }
}
