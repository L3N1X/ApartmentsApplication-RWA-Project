using RwaApartmaniDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Repositories.Interfaces
{
    public interface IRepo
    {
        //Apartment
        IList<Apartment> LoadApartments();
        Apartment LoadApartmentById(int id);
        void InsertApartment(Apartment apartment);
        void DeleteApartment(int id);
        IList<Apartment> LoadApartments(params Predicate<Apartment>[] filters);
        //ApartmentOwner
        IList<ApartmentOwner> LoadApartmentOwners();
        ApartmentOwner LoadApartmentOwnerById(int id);
        void InsertApartmentOwner(ApartmentOwner apartmentOwner);
        //ApartmentPicture
        IList<ApartmentPicture> LoadApartmentPictures();
        ApartmentPicture LoadApartmentPictureById(int id);
        void InsertApartmentPicture(ApartmentPicture apartmentPicture);
        void DeleteApartmentPicture(int id);
        //ApartmentReservation
        IList<ApartmentReservation> LoadApartmentReservations();
        ApartmentReservation LoadApartmentReservationById(int id);
        void InsertApartmentReservation(ApartmentReservation apartmentReservation);
        //ApartmentReview
        IList<ApartmentReview> LoadApartmentReviews();
        ApartmentReview LoadApartmentReviewById(int id);
        void InsertApartmentReview(ApartmentReview apartmentReivew);
        //ApartmentStatus
        IList<ApartmentStatus> LoadApartmentStatus();
        ApartmentStatus LoadApartmentStatusById(int id);
        void InsertApartmentStatus(ApartmentStatus apartmentStatus);
        //City
        IList<City> LoadCities();
        City LoadCitiyById(int id);
        void InsertCity(City city);
        //Tag
        IList<Tag> LoadTags();
        Tag LoadTagById(int id);
        void InsertTag(Tag tag);
        void DeleteTag(int id);
        //TaggedApartment
        IList<TaggedApartment> LoadTaggedApartments();
        TaggedApartment LoadTaggedApartmentById(int id);
        void InsertTaggedApartment(TaggedApartment taggedApartment);
        void DeleteTaggedApartment(int id);
        //TagType
        IList<TagType> LoadTagTypes();
        TagType LoadTagTypeById(int id);
        void InsertTagType(TagType tagType);
        //User
        IList<User> LoadUsers();
        User LoadUserById(int id);
        void InsertUser(User user);
        void DeleteUser(int id);
        User AuthUser(string username, string password);
    }
}
