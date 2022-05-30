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
using RwaApartmaniDataLayer.Utilities;

namespace RwaApartmaniDataLayer.Repositories.Abstracts
{
    public class AbstractDBRepo : IRepo
    {
        private static string APARTMENS_CS = ConfigurationManager.ConnectionStrings["apartments"].ConnectionString;
        //Abstract Repo methods

        //Apartments
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
                        Guid = (Guid)row[nameof(Apartment.Guid)],
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

        //ApartmentOwners
        private IList<ApartmentOwner> LoadApartmentOwnersRaw()
        {
            IList<ApartmentOwner> apartmentsPictures = new List<ApartmentOwner>();

            var tblApartmentOwners = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentOwners)).Tables[0];
            foreach (DataRow row in tblApartmentOwners.Rows)
            {
                apartmentsPictures.Add(
                    new ApartmentOwner
                    {
                        Id = (int)(row[nameof(ApartmentOwner.Id)]),
                        Name = (string)row[nameof(ApartmentOwner.Name)],
                        CreatedAt = (DateTime)row[nameof(ApartmentOwner.CreatedAt)],
                        Guid = (Guid)row[nameof(ApartmentOwner.Guid)],
                    }
                );
            }

            return apartmentsPictures;
        }

        //ApartmentPictures
        private IList<ApartmentPicture> LoadApartmentPicturesRaw()
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();

            var tblApartmentPictures = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentPictures)).Tables[0];
            foreach (DataRow row in tblApartmentPictures.Rows)
            {
                apartmentPictures.Add(
                    new ApartmentPicture
                    {
                        Id = (int)(row[nameof(ApartmentPicture.Id)]),
                        Name = (string)row[nameof(ApartmentPicture.Name)],
                        CreatedAt = (DateTime)row[nameof(ApartmentPicture.CreatedAt)],
                        Guid = (Guid)row[nameof(ApartmentPicture.Guid)],
                        ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)],
                        //Base64Content = (string)row[nameof(ApartmentPicture.Base64Content)],
                        IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)],
                        Path = (string)row[nameof(ApartmentPicture.Path)],
                    }
                );
            }

            return apartmentPictures;
        }

        //ApartmentReservations
        private IList<ApartmentPicture> LoadApartmentReservationsRaw()
        {
            IList<ApartmentReservation> apartmentOwners = new List<ApartmentReservation>();

            var tblApartmentReservations = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReservations)).Tables[0];
            foreach (DataRow row in tblApartmentReservations.Rows)
            {
                apartmentOwners.Add(
                    new ApartmentReservation
                    {
                        Id = (int)(row[nameof(ApartmentReservation.Id)]),
                        CreatedAt = (DateTime)row[nameof(ApartmentReservation.CreatedAt)],
                        Guid = (Guid)row[nameof(ApartmentReservation.Guid)],
                        ApartmentId = (int)row[nameof(ApartmentReservation.ApartmentId)],
                    }
                );
            }

            return apartmentOwners;
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

        public IList<ApartmentPicture> LoadApartmentPictures()
        {
            return LoadApartmentPicturesRaw();
        }

        public IList<ApartmentReservation> LoadApartmentReservations()
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

        public IList<ApartmentOwner> LoadApartmentOwners()
        {
            return LoadApartmentOwnersRaw();
        }

        public ApartmentOwner LoadApartmentOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertApartmentOwner(ApartmentOwner apartmentOwner)
        {
            throw new NotImplementedException();
        }
        //Interface methods
    }
}
