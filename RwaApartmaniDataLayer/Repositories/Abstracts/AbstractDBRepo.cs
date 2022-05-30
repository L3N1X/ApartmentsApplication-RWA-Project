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
        private Apartment LoadApartmentByIdRaw()
        {
            var tblApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentById)).Tables[0];
            if (tblApartments.Rows.Count == 0) return null;

            DataRow row = tblApartments.Rows[0];
            return new Apartment
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
            };
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

        private ApartmentOwner LoadApartmentOwnerByIdRaw()
        {
            var tblApartmentOwners = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentOwnerById)).Tables[0];
            if (tblApartmentOwners.Rows.Count == 0) return null;

            DataRow row = tblApartmentOwners.Rows[0];
            return new ApartmentOwner
            {
                Id = (int)(row[nameof(ApartmentOwner.Id)]),
                Name = (string)row[nameof(ApartmentOwner.Name)],
                CreatedAt = (DateTime)row[nameof(ApartmentOwner.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentOwner.Guid)],
            };
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

        private ApartmentPicture LoadApartmentPictureByIdRaw()
        {
            var tblApartmentPictures = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentPictureById)).Tables[0];
            if (tblApartmentPictures.Rows.Count == 0) return null;

            DataRow row = tblApartmentPictures.Rows[0];
            return new ApartmentPicture
            {
                Id = (int)(row[nameof(ApartmentPicture.Id)]),
                Name = (string)row[nameof(ApartmentPicture.Name)],
                CreatedAt = (DateTime)row[nameof(ApartmentPicture.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentPicture.Guid)],
                ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)],
                //Base64Content = (string)row[nameof(ApartmentPicture.Base64Content)],
                IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)],
                Path = (string)row[nameof(ApartmentPicture.Path)],
            };
        }

        //ApartmentReservations
        private IList<ApartmentReservation> LoadApartmentReservationsRaw()
        {
            IList<ApartmentReservation> apartmentReservations = new List<ApartmentReservation>();

            var tblApartmentReservations = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReservations)).Tables[0];
            foreach (DataRow row in tblApartmentReservations.Rows)
            {
                apartmentReservations.Add(
                    new ApartmentReservation
                    {
                        Id = (int)(row[nameof(ApartmentReservation.Id)]),
                        CreatedAt = (DateTime)row[nameof(ApartmentReservation.CreatedAt)],
                        Guid = (Guid)row[nameof(ApartmentReservation.Guid)],
                        ApartmentId = (int)row[nameof(ApartmentReservation.ApartmentId)],
                        Details = (string)row[nameof(ApartmentReservation.Details)],
                        UserAddress = (string)row[nameof(ApartmentReservation.UserAddress)],
                        UserEmail = (string)row[nameof(ApartmentReservation.UserEmail)],
                        UserId = (int)row[nameof(ApartmentReservation.UserId)],
                        UserName = (string)row[nameof(ApartmentReservation.UserName)],
                        UserPhone = (string)row[nameof(ApartmentReservation.UserPhone)],
                    }
                );
            }

            return apartmentReservations;
        }

        private ApartmentReservation LoadApartmentReservationByIdRaw()
        {
            var tblApartmentReservations = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReservationById)).Tables[0];
            if (tblApartmentReservations.Rows.Count == 0) return null;

            DataRow row = tblApartmentReservations.Rows[0];
            return new ApartmentReservation
            {
                Id = (int)(row[nameof(ApartmentReservation.Id)]),
                CreatedAt = (DateTime)row[nameof(ApartmentReservation.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentReservation.Guid)],
                ApartmentId = (int)row[nameof(ApartmentReservation.ApartmentId)],
                Details = (string)row[nameof(ApartmentReservation.Details)],
                UserAddress = (string)row[nameof(ApartmentReservation.UserAddress)],
                UserEmail = (string)row[nameof(ApartmentReservation.UserEmail)],
                UserId = (int)row[nameof(ApartmentReservation.UserId)],
                UserName = (string)row[nameof(ApartmentReservation.UserName)],
                UserPhone = (string)row[nameof(ApartmentReservation.UserPhone)],
            };
        }

        //ApartmentReview
        private IList<ApartmentReview> LoadApartmentReviewsRaw()
        {
            IList<ApartmentReview> apartmentReviews = new List<ApartmentReview>();

            var tblApartmentReviews = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReviews)).Tables[0];
            foreach (DataRow row in tblApartmentReviews.Rows)
            {
                apartmentReviews.Add(
                    new ApartmentReview
                    {
                        Id = (int)(row[nameof(ApartmentReview.Id)]),
                        CreatedAt = (DateTime)row[nameof(ApartmentReview.CreatedAt)],
                        Guid = (Guid)row[nameof(ApartmentReview.Guid)],
                        ApartmentId = (int)row[nameof(ApartmentReview.ApartmentId)],
                        Details = (string)row[nameof(ApartmentReview.Details)],
                        Stars = (int)row[nameof(ApartmentReview.Stars)],
                        UserId = (int)row[nameof(ApartmentReview.UserId)],
                    }
                );
            }

            return apartmentReviews;
        }

        private ApartmentReview LoadApartmentReviewByIdRaw()
        {
            var tblApartmentReviews = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReviewById)).Tables[0];
            if (tblApartmentReviews.Rows.Count == 0) return null;

            DataRow row = tblApartmentReviews.Rows[0];
            return new ApartmentReview
            {
                Id = (int)(row[nameof(ApartmentReview.Id)]),
                CreatedAt = (DateTime)row[nameof(ApartmentReview.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentReview.Guid)],
                ApartmentId = (int)row[nameof(ApartmentReview.ApartmentId)],
                Details = (string)row[nameof(ApartmentReview.Details)],
                Stars = (int)row[nameof(ApartmentReview.Stars)],
                UserId = (int)row[nameof(ApartmentReview.UserId)],
            };
        }

        //ApartmentStatus
        private IList<ApartmentStatus> LoadApartmentStatusRaw()
        {
            IList<ApartmentStatus> apartmentStatus = new List<ApartmentStatus>();

            var tblApartmentStatus = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentStatus)).Tables[0];
            foreach (DataRow row in tblApartmentStatus.Rows)
            {
                apartmentStatus.Add(
                    new ApartmentStatus
                    {
                        Id = (int)(row[nameof(ApartmentStatus.Id)]),
                        Guid = (Guid)row[nameof(ApartmentStatus.Guid)],
                        Name = (string)row[nameof(ApartmentStatus.Name)],
                        NameEng = (string)row[nameof(ApartmentStatus.NameEng)],
                    }
                );
            }

            return apartmentStatus;
        }

        private ApartmentStatus LoadApartmentStatusByIdRaw()
        {
            var tblApartmentStatus = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentStatusById)).Tables[0];
            if (tblApartmentStatus.Rows.Count == 0) return null;

            DataRow row = tblApartmentStatus.Rows[0];
            return new ApartmentStatus
            {
                Id = (int)(row[nameof(ApartmentStatus.Id)]),
                Guid = (Guid)row[nameof(ApartmentStatus.Guid)],
                Name = (string)row[nameof(ApartmentStatus.Name)],
                NameEng = (string)row[nameof(ApartmentStatus.NameEng)],
            };
        }

        //Cities
        private IList<City> LoadCitiesRaw()
        {
            IList<City> cities = new List<City>();

            var tblCites = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadCities)).Tables[0];
            foreach (DataRow row in tblCites.Rows)
            {
                cities.Add(
                    new City
                    {
                        Id = (int)(row[nameof(City.Id)]),
                        Guid = (Guid)row[nameof(City.Guid)],
                        Name = (string)row[nameof(City.Name)],
                    }
                );
            }

            return cities;
        }

        private City LoadCityByIdRaw()
        {
            var tblCities = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadCitiyById)).Tables[0];
            if (tblCities.Rows.Count == 0) return null;

            DataRow row = tblCities.Rows[0];
            return new City
            {
                Id = (int)(row[nameof(City.Id)]),
                Guid = (Guid)row[nameof(City.Guid)],
                Name = (string)row[nameof(City.Name)],
            };
        }

        //Tags
        private IList<Tag> LoadTagsRaw()
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTags)).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tag
                    {
                        Id = (int)(row[nameof(Tag.Id)]),
                        Guid = (Guid)row[nameof(Tag.Guid)],
                        Name = (string)row[nameof(Tag.Name)],
                        CreatedAt = (DateTime)row[nameof(Tag.CreatedAt)],
                        NameEng = (string)row[nameof(Tag.NameEng)],
                        TypeId = (int)row[nameof(Tag.TypeId)],
                    }
                );
            }

            return tags;
        }

        private Tag LoadTagByIdRaw()
        {
            var tblTags = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagById)).Tables[0];
            if (tblTags.Rows.Count == 0) return null;

            DataRow row = tblTags.Rows[0];
            return new Tag
            {
                Id = (int)(row[nameof(Tag.Id)]),
                Guid = (Guid)row[nameof(Tag.Guid)],
                Name = (string)row[nameof(Tag.Name)],
                CreatedAt = (DateTime)row[nameof(Tag.CreatedAt)],
                NameEng = (string)row[nameof(Tag.NameEng)],
                TypeId = (int)row[nameof(Tag.TypeId)],
            };
        }

        //TaggedApartments
        private IList<TaggedApartment> LoadTaggedApartmentsRaw()
        {
            IList<TaggedApartment> taggedApartments = new List<TaggedApartment>();

            var tblTaggedApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTaggedApartments)).Tables[0];
            foreach (DataRow row in tblTaggedApartments.Rows)
            {
                taggedApartments.Add(
                    new TaggedApartment
                    {
                        Id = (int)(row[nameof(TaggedApartment.Id)]),
                        Guid = (Guid)row[nameof(TaggedApartment.Guid)],
                        ApartmentId = (int)row[nameof(TaggedApartment.ApartmentId)],
                        TagId = (int)row[nameof(TaggedApartment.TagId)],
                    }
                );
            }

            return taggedApartments;
        }

        private TaggedApartment LoadTaggedApartmentsByIdRaw()
        {
            var tblTaggedApartmets = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTaggedApartmentById)).Tables[0];
            if (tblTaggedApartmets.Rows.Count == 0) return null;

            DataRow row = tblTaggedApartmets.Rows[0];
            return new TaggedApartment
            {
                Id = (int)(row[nameof(TaggedApartment.Id)]),
                Guid = (Guid)row[nameof(TaggedApartment.Guid)],
                ApartmentId = (int)row[nameof(TaggedApartment.ApartmentId)],
                TagId = (int)row[nameof(TaggedApartment.TagId)],
            };
        }

        //TagTypes
        private IList<TagType> LoadTagTypesRaw()
        {
            IList<TagType> tagTypes = new List<TagType>();

            var tblTagTypes = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagTypes)).Tables[0];
            foreach (DataRow row in tblTagTypes.Rows)
            {
                tagTypes.Add(
                    new TagType
                    {
                        Id = (int)(row[nameof(TagType.Id)]),
                        Guid = (Guid)row[nameof(TagType.Guid)],
                        Name = (string)row[nameof(TagType.Name)],
                        NameEng = (string)row[nameof(TagType.NameEng)],
                    }
                );
            }

            return tagTypes;
        }

        private TagType LoadTagTypesByIdRaw()
        {
            var tblTagTypes = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagTypesByIdRaw)).Tables[0];
            if (tblTagTypes.Rows.Count == 0) return null;

            DataRow row = tblTagTypes.Rows[0];
            return new TagType
            {
                Id = (int)(row[nameof(TagType.Id)]),
                Guid = (Guid)row[nameof(TagType.Guid)],
                Name = (string)row[nameof(TagType.Name)],
                NameEng = (string)row[nameof(TagType.NameEng)],
            };
        }

        //Users
        private IList<User> LoadUsersRaw()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        Id = (int)(row[nameof(User.Id)]),
                        Guid = (Guid)row[nameof(User.Guid)],
                        Address = (string)row[nameof(User.Address)],
                        CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                        //DeletedAt = (DateTime)row[nameof(User.DeletedAt)],
                        Email = (string)row[nameof(User.Email)],
                        PasswordHash = (string)row[nameof(User.PasswordHash)],
                        PhoneNumber = (string)row[nameof(User.PhoneNumber)],
                        UserName = (string)row[nameof(User.UserName)],
                    }
                );
            }

            return users;
        }

        private User LoadUserByIdRaw()
        {
            var tblUsers = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUserById)).Tables[0];
            if (tblUsers.Rows.Count == 0) return null;

            DataRow row = tblUsers.Rows[0];
            return new User
            {
                Id = (int)(row[nameof(User.Id)]),
                Guid = (Guid)row[nameof(User.Guid)],
                Address = (string)row[nameof(User.Address)],
                CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                //DeletedAt = (DateTime)row[nameof(User.DeletedAt)],
                Email = (string)row[nameof(User.Email)],
                PasswordHash = (string)row[nameof(User.PasswordHash)],
                PhoneNumber = (string)row[nameof(User.PhoneNumber)],
                UserName = (string)row[nameof(User.UserName)],
            };
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
            throw new NotImplementedException();
        }

        public IList<ApartmentPicture> LoadApartmentPictures()
        {
            throw new NotImplementedException();
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
