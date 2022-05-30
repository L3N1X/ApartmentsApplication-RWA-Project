using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RwaApartmaniDataLayer.Repositories.Abstracts
{
    public class AbstractDBRepo : IRepo
    {
        private static string APARTMENS_CS = ConfigurationManager.ConnectionStrings["apartments"].ConnectionString;
        //Abstract Repo methods

        private IList<Apartment> LoadApartmentsRaw()
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartments)).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Id = (int)(row[nameof(Apartment.Id)]),
                        Name = (string)row[nameof(Apartment.Name)],
                        Address = (string)row[nameof(Apartment.Address)],
                        CityId = (int)(row[nameof(Apartment.CityId)]),
                        BeachDistance = (int)row[nameof(Apartment.BeachDistance)],
                        CreatedAt = (DateTime)row[nameof(Apartment.CreatedAt)],
                        DeletedAt = (DateTime)row[nameof(Apartment.DeletedAt)] == null ?  null : (DateTime)row[nameof(Apartment.DeletedAt)],
                        //Guid = Guid.Parse((string)row[nameof(Apartment.Guid)]),
                        MaxAdults = (int)row[nameof(Apartment.MaxAdults)],
                        MaxChildren = (int)row[nameof(Apartment.MaxChildren)],
                        OwnerId = (int)row[nameof(Apartment.OwnerId)],
                        Price = (decimal)row[nameof(Apartment.Price)],
                        StatusId = (int)row[nameof(Apartment.StatusId)],
                        TotalRooms = (int)row[nameof(Apartment.TotalRooms)],
                        TypeId = (int)row[nameof(Apartment.TypeId)]
                    }
                );
            }

            return apartments;
        }

        //Abstract Repo methods


        //Interface methods
        public User AuthUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteApartment(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteApartmentPicture(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTaggedApartment(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertApartment(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public void InsertApartmentPicture(ApartmentPicture apartmentPicture)
        {
            throw new NotImplementedException();
        }

        public void InsertApartmentReservation(ApartmentReservation apartmentReservation)
        {
            throw new NotImplementedException();
        }

        public void InsertApartmentReview(ApartmentReview apartmentReivew)
        {
            throw new NotImplementedException();
        }

        public void InsertApartmentStatus(ApartmentStatus apartmentStatus)
        {
            throw new NotImplementedException();
        }

        public void InsertCity(City city)
        {
            throw new NotImplementedException();
        }

        public void InsertTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void InsertTaggedApartment(TaggedApartment taggedApartment)
        {
            throw new NotImplementedException();
        }

        public void InsertTagType(TagType tagType)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public Apartment LoadApartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public ApartmentPicture LoadApartmentPictureById(int id)
        {
            throw new NotImplementedException();
        }

        public ApartmentReservation LoadApartmentReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public ApartmentReview LoadApartmentReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ApartmentReview> LoadApartmentReviews()
        {
            throw new NotImplementedException();
        }

        public IList<Apartment> LoadApartments()
        {
            return LoadApartmentsRaw();
        }

        public IList<ApartmentPicture> LoadApartmentsPictures()
        {
            throw new NotImplementedException();
        }

        public IList<ApartmentReservation> LoadApartmentsReservations()
        {
            throw new NotImplementedException();
        }

        public IList<ApartmentStatus> LoadApartmentStatus()
        {
            throw new NotImplementedException();
        }

        public ApartmentStatus LoadApartmentStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<City> LoadCities()
        {
            throw new NotImplementedException();
        }

        public City LoadCitiyById(int id)
        {
            throw new NotImplementedException();
        }

        public Tag LoadTagById(int id)
        {
            throw new NotImplementedException();
        }

        public TaggedApartment LoadTaggedApartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TaggedApartment> LoadTaggedApartments()
        {
            throw new NotImplementedException();
        }

        public IList<Tag> LoadTags()
        {
            throw new NotImplementedException();
        }

        public TagType LoadTagTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TagType> LoadTagTypes()
        {
            throw new NotImplementedException();
        }

        public User LoadUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> LoadUsers()
        {
            throw new NotImplementedException();
        }
        //Interface methods
    }
}
