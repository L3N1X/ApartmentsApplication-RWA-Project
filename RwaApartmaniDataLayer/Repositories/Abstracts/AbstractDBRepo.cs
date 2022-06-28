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
    public abstract class AbstractDBRepo : IRepo
    {
        public static string APARTMENS_CS = ConfigurationManager.ConnectionStrings["apartments"].ConnectionString;

        //Abstract Repo methods

        //Apartments
        internal IList<Apartment> LoadApartmentsRaw()
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
                        NameEng = (string)row[nameof(Apartment.NameEng)],
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
        internal Apartment LoadApartmentByIdRaw(int id)
        {
            var tblApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentById), id).Tables[0];
            if (tblApartments.Rows.Count == 0) return null;

            DataRow row = tblApartments.Rows[0];
            return new Apartment
            {
                Id = (int)(row[nameof(Apartment.Id)]),
                Name = (string)row[nameof(Apartment.Name)],
                NameEng = (string)row[nameof(Apartment.NameEng)],
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
        internal IList<ApartmentOwner> LoadApartmentOwnersRaw()
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

        internal ApartmentOwner LoadApartmentOwnerByIdRaw(int id)
        {
            var tblApartmentOwners = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentOwnerById), id).Tables[0];
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
        internal IList<ApartmentPicture> LoadApartmentPicturesRaw()
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
                        Base64Content = (string)row[nameof(ApartmentPicture.Base64Content)],
                        IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)],
                        Path = !DBNull.Value.Equals(row[nameof(ApartmentPicture.Path)]) ? (string)row[nameof(ApartmentPicture.Path)] : null,
                    }
                );
            }

            return apartmentPictures;
        }

        internal ApartmentPicture LoadApartmentPictureByIdRaw(int id)
        {
            var tblApartmentPictures = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentPictureById), id).Tables[0];
            if (tblApartmentPictures.Rows.Count == 0) return null;

            DataRow row = tblApartmentPictures.Rows[0];
            return new ApartmentPicture
            {
                Id = (int)(row[nameof(ApartmentPicture.Id)]),
                Name = (string)row[nameof(ApartmentPicture.Name)],
                CreatedAt = (DateTime)row[nameof(ApartmentPicture.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentPicture.Guid)],
                ApartmentId = (int)row[nameof(ApartmentPicture.ApartmentId)],
                Base64Content = (string)row[nameof(ApartmentPicture.Base64Content)],
                IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)],
                Path = !DBNull.Value.Equals(row[nameof(ApartmentPicture.Path)]) ? (string)row[nameof(ApartmentPicture.Path)] : null,
            };
        }

        //ApartmentReservations
        internal IList<ApartmentReservation> LoadApartmentReservationsRaw()
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
                        UserAddress = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserAddress)]) ? (string)row[nameof(ApartmentReservation.UserAddress)] : null,
                        UserEmail = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserEmail)]) ? (string)row[nameof(ApartmentReservation.UserEmail)] : null,
                        UserId = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserId)]) ? (int?)row[nameof(ApartmentReservation.UserId)] : null,
                        UserName = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserName)]) ? (string)row[nameof(ApartmentReservation.UserName)] : null,
                        UserPhone = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserPhone)]) ? (string)row[nameof(ApartmentReservation.UserPhone)] : null,
                    }
                );
            }

            return apartmentReservations;
        }

        internal ApartmentReservation LoadApartmentReservationByIdRaw(int id)
        {
            var tblApartmentReservations = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReservationById), id).Tables[0];
            if (tblApartmentReservations.Rows.Count == 0) return null;

            DataRow row = tblApartmentReservations.Rows[0];
            return new ApartmentReservation
            {
                Id = (int)(row[nameof(ApartmentReservation.Id)]),
                CreatedAt = (DateTime)row[nameof(ApartmentReservation.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentReservation.Guid)],
                ApartmentId = (int)row[nameof(ApartmentReservation.ApartmentId)],
                Details = (string)row[nameof(ApartmentReservation.Details)],
                UserAddress = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserAddress)]) ? (string)row[nameof(ApartmentReservation.UserAddress)] : null,
                UserEmail = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserEmail)]) ? (string)row[nameof(ApartmentReservation.UserEmail)] : null,
                UserId = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserId)]) ? (int?)row[nameof(ApartmentReservation.UserId)] : null,
                UserName = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserName)]) ? (string)row[nameof(ApartmentReservation.UserName)] : null,
                UserPhone = !DBNull.Value.Equals(row[nameof(ApartmentReservation.UserPhone)]) ? (string)row[nameof(ApartmentReservation.UserPhone)] : null,
            };
        }

        //ApartmentReview
        internal IList<ApartmentReview> LoadApartmentReviewsRaw()
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
                        Details = !DBNull.Value.Equals(row[nameof(ApartmentReview.Details)]) ? (string)row[nameof(ApartmentReview.Details)] : null,
                        Stars = (int)row[nameof(ApartmentReview.Stars)],
                        UserId = (int)row[nameof(ApartmentReview.UserId)],
                    }
                );
            }

            return apartmentReviews;
        }

        internal ApartmentReview LoadApartmentReviewByIdRaw(int id)
        {
            var tblApartmentReviews = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReviewById), id).Tables[0];
            if (tblApartmentReviews.Rows.Count == 0) return null;

            DataRow row = tblApartmentReviews.Rows[0];
            return new ApartmentReview
            {
                Id = (int)(row[nameof(ApartmentReview.Id)]),
                CreatedAt = (DateTime)row[nameof(ApartmentReview.CreatedAt)],
                Guid = (Guid)row[nameof(ApartmentReview.Guid)],
                ApartmentId = (int)row[nameof(ApartmentReview.ApartmentId)],
                Details = !DBNull.Value.Equals(row[nameof(ApartmentReview.Details)]) ? (string)row[nameof(ApartmentReview.Details)] : null,
                Stars = (int)row[nameof(ApartmentReview.Stars)],
                UserId = (int)row[nameof(ApartmentReview.UserId)],
            };
        }

        //ApartmentStatus
        internal IList<ApartmentStatus> LoadApartmentStatusRaw()
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

        internal ApartmentStatus LoadApartmentStatusByIdRaw(int id)
        {
            var tblApartmentStatus = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentStatusById), id).Tables[0];
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
        internal IList<City> LoadCitiesRaw()
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

        internal City LoadCityByIdRaw(int id)
        {
            var tblCities = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadCitiyById), id).Tables[0];
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
        internal IList<Tag> LoadTagsRaw()
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

        internal Tag LoadTagByIdRaw(int id)
        {
            var tblTags = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagById), id).Tables[0];
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
        internal IList<TaggedApartment> LoadTaggedApartmentsRaw()
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

        internal TaggedApartment LoadTaggedApartmentsByIdRaw(int id)
        {
            var tblTaggedApartmets = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTaggedApartmentById), id).Tables[0];
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
        internal IList<TagType> LoadTagTypesRaw()
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

        internal TagType LoadTagTypesByIdRaw(int id)
        {
            var tblTagTypes = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagTypeById), id).Tables[0];
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
        internal IList<User> LoadUsersRaw()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        Id = ((int)(row[nameof(User.Id)])).ToString(),
                        Guid = (Guid)row[nameof(User.Guid)],
                        Address = (string)row[nameof(User.Address)],
                        CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                        //DeletedAt = (DateTime)row[nameof(User.DeletedAt)],
                        Email = (string)row[nameof(User.Email)],
                        PasswordHash = !DBNull.Value.Equals(row[nameof(User.PasswordHash)]) ? (string)row[nameof(User.PasswordHash)] : null,
                        PhoneNumber = (string)row[nameof(User.PhoneNumber)],
                        UserName = (string)row[nameof(User.UserName)],
                    }
                );
            }

            /***REMOVE***/

            foreach (var user in users)
            {
                user.Roles = new List<string>();
                user.AddRole("user");
            }

            /***REMOVE***/

            return users;
        }

        internal User LoadUserByIdRaw(int id)
        {
            var tblUsers = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUserById), id).Tables[0];
            if (tblUsers.Rows.Count == 0) return null;

            DataRow row = tblUsers.Rows[0];
            return new User
            {
                Id = ((int)(row[nameof(User.Id)])).ToString(),
                Guid = (Guid)row[nameof(User.Guid)],
                Address = (string)row[nameof(User.Address)],
                CreatedAt = (DateTime)row[nameof(User.CreatedAt)],
                //DeletedAt = (DateTime)row[nameof(User.DeletedAt)],
                Email = (string)row[nameof(User.Email)],
                PasswordHash = !DBNull.Value.Equals(row[nameof(User.PasswordHash)]) ? (string)row[nameof(User.PasswordHash)] : null,
                PhoneNumber = (string)row[nameof(User.PhoneNumber)],
                UserName = (string)row[nameof(User.UserName)],
            };
        }

        //Abstract Repo methods


        //Interface methods
        public abstract User AuthUser(string username, string password);

        public abstract void DeleteApartment(Apartment apartment);

        public abstract void DeleteApartmentPicture(Guid guid);

        public abstract void DeleteTag(int id);

        public abstract void DeleteTaggedApartment(int id);

        public abstract void DeleteUser(int id);

        public abstract void InsertApartment(Apartment apartment);

        public abstract void InsertApartmentPicture(ApartmentPicture apartmentPicture);

        public abstract void InsertApartmentReservation(ApartmentReservation apartmentReservation);

        public abstract void InsertApartmentReview(ApartmentReview apartmentReivew);

        public abstract void InsertApartmentStatus(ApartmentStatus apartmentStatus);

        public abstract void InsertCity(City city);

        public abstract void InsertTag(Tag tag);

        public abstract void InsertTaggedApartment(TaggedApartment taggedApartment);

        public abstract void InsertTagType(TagType tagType);

        public abstract void InsertUser(User user);

        public abstract Apartment LoadApartmentById(int id);

        public abstract ApartmentPicture LoadApartmentPictureById(int id);

        public abstract ApartmentReservation LoadApartmentReservationById(int id);

        public abstract ApartmentReview LoadApartmentReviewById(int id);

        public abstract IList<ApartmentReview> LoadApartmentReviews();

        public abstract IList<Apartment> LoadApartments();

        public abstract IList<ApartmentPicture> LoadApartmentPictures();

        public abstract IList<ApartmentReservation> LoadApartmentReservations();

        public abstract IList<ApartmentStatus> LoadApartmentStatus();

        public abstract ApartmentStatus LoadApartmentStatusById(int id);

        public abstract IList<City> LoadCities();

        public abstract City LoadCitiyById(int id);

        public abstract Tag LoadTagById(int id);

        public abstract TaggedApartment LoadTaggedApartmentById(int id);

        public abstract IList<TaggedApartment> LoadTaggedApartments();

        public abstract IList<Tag> LoadTags();

        public abstract TagType LoadTagTypeById(int id);

        public abstract IList<TagType> LoadTagTypes();

        public abstract User LoadUserById(int id);

        public abstract IList<User> LoadUsers();

        public abstract IList<ApartmentOwner> LoadApartmentOwners();

        public abstract ApartmentOwner LoadApartmentOwnerById(int id);

        public abstract void InsertApartmentOwner(ApartmentOwner apartmentOwner);

        public abstract IList<Apartment> LoadApartments(params Predicate<Apartment>[] filters);

        public abstract IList<ApartmentPicture> LoadApartmentPicturesByApartmentId(int id);

        public abstract IList<Apartment> LoadApartmentsByOwnerId(int id);

        public abstract IList<Tag> LoadTagsByApartmentId(int id);

        public abstract IList<Tuple<Tag, int>> LoadTagsCounted();

        public abstract void UpdateApartment(Apartment apartment, IList<ApartmentPicture> picturesToRemove);

        public abstract IList<string> LoadApartmentNames();

        public abstract IList<ApartmentReview> LoadApartmentReviewsByApartmentId(int id);
        //Interface methods
    }
}
