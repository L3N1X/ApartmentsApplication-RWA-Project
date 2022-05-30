using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Repositories.Implementations
{
    public partial class DBRepo : AbstractDBRepo
    {
        //Move to abstract class as much as possible
        public override User AuthUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override void DeleteApartment(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteApartmentPicture(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteTaggedApartment(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartment(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentOwner(ApartmentOwner apartmentOwner)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentPicture(ApartmentPicture apartmentPicture)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentReservation(ApartmentReservation apartmentReservation)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentReview(ApartmentReview apartmentReivew)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentStatus(ApartmentStatus apartmentStatus)
        {
            throw new NotImplementedException();
        }

        public override void InsertCity(City city)
        {
            throw new NotImplementedException();
        }

        public override void InsertTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public override void InsertTaggedApartment(TaggedApartment taggedApartment)
        {
            throw new NotImplementedException();
        }

        public override void InsertTagType(TagType tagType)
        {
            throw new NotImplementedException();
        }

        public override void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public override Apartment LoadApartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public override ApartmentOwner LoadApartmentOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ApartmentOwner> LoadApartmentOwners()
        {
            throw new NotImplementedException();
        }

        public override ApartmentPicture LoadApartmentPictureById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ApartmentPicture> LoadApartmentPictures()
        {
            throw new NotImplementedException();
        }

        public override ApartmentReservation LoadApartmentReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ApartmentReservation> LoadApartmentReservations()
        {
            throw new NotImplementedException();
        }

        public override ApartmentReview LoadApartmentReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ApartmentReview> LoadApartmentReviews()
        {
            throw new NotImplementedException();
        }

        public override IList<Apartment> LoadApartments()
        {
            throw new NotImplementedException();
        }

        public override IList<Apartment> LoadApartments(params Predicate<Apartment>[] filters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApartmentStatus> LoadApartmentStatus()
        {
            throw new NotImplementedException();
        }

        public override ApartmentStatus LoadApartmentStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<City> LoadCities()
        {
            throw new NotImplementedException();
        }

        public override City LoadCitiyById(int id)
        {
            throw new NotImplementedException();
        }

        public override Tag LoadTagById(int id)
        {
            throw new NotImplementedException();
        }

        public override TaggedApartment LoadTaggedApartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<TaggedApartment> LoadTaggedApartments()
        {
            throw new NotImplementedException();
        }

        public override IList<Tag> LoadTags()
        {
            throw new NotImplementedException();
        }

        public override TagType LoadTagTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<TagType> LoadTagTypes()
        {
            throw new NotImplementedException();
        }

        public override User LoadUserById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<User> LoadUsers()
        {
            throw new NotImplementedException();
        }
    }
}
