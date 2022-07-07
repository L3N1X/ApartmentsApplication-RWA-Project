using Microsoft.ApplicationBlocks.Data;
using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaApartmaniDataLayer.Repositories.Implementations
{
    public partial class DBRepo : AbstractDBRepo
    {
        private int LoadApartmentIdByGuid(Guid guid)
        {
            int apartmentId = 1;
            var tblApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentIdByGuid), guid).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartmentId = (int)(row[nameof(Apartment.Id)]);
            }

            return apartmentId;
        }

        private void DeleteTaggedApartmentByApartmentId(int apartmentId)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTaggedApartmentByApartmentId), apartmentId);
        }

        private void DeleteTaggedApartment(TaggedApartment taggedApartment)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTaggedApartment), taggedApartment.ApartmentId, taggedApartment.TagId);
        }

        //Move to abstract class as much as possible
        public override User AuthUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override void DeleteApartment(Apartment apartment)
        {
            foreach (var tag in apartment.Tags)
                this.DeleteTaggedApartment(new TaggedApartment { TagId = tag.Id, ApartmentId = apartment.Id });
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteApartment), apartment.Id);
        }

        public override void DeleteApartmentPicture(Guid guid)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteApartmentPicture), guid);
        }

        public override void DeleteTag(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTag), id);
        }

        public override void DeleteTaggedApartment(int id)
        {
            //Don't use!!!!!
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTaggedApartment), id);
        }

        public override void DeleteUser(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteUser), id);
        }

        public override void InsertApartment(Apartment apartment)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertApartment),
                apartment.Guid,
                apartment.CreatedAt,
                apartment.OwnerId,
                apartment.StatusId,
                apartment.CityId,
                apartment.Address,
                apartment.Name,
                apartment.NameEng,
                apartment.Price,
                apartment.MaxAdults,
                apartment.MaxChildren,
                apartment.TotalRooms, 
                apartment.BeachDistance);
            int apartmentId = LoadApartmentIdByGuid(apartment.Guid); //Gets id from database to resolve foreign key errors
            foreach (Tag tag in apartment.Tags)
                InsertTaggedApartment(new TaggedApartment { Guid = Guid.NewGuid(), ApartmentId = apartmentId, TagId = tag.Id });
            foreach (ApartmentPicture picture in apartment.Pictures)
            {
                picture.ApartmentId = apartmentId;
                InsertApartmentPicture(picture);
            }
        }

        public override void InsertApartmentOwner(ApartmentOwner apartmentOwner)
        {
            throw new NotImplementedException();
        }

        public override void InsertApartmentPicture(ApartmentPicture apartmentPicture)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertApartmentPicture),
                    apartmentPicture.Guid,
                    apartmentPicture.CreatedAt,
                    apartmentPicture.ApartmentId,
                    apartmentPicture.Path,
                    apartmentPicture.Base64Content,
                    apartmentPicture.Name,
                    apartmentPicture.IsRepresentative
                );
        }

        public override void InsertApartmentReservation(ApartmentReservation apartmentReservation)
        {
            string details = apartmentReservation.Details;
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertApartmentReservation),
                apartmentReservation.Guid,
                apartmentReservation.CreatedAt,
                apartmentReservation.ApartmentId,
                apartmentReservation.Details,
                apartmentReservation.UserId,
                apartmentReservation.UserName,
                apartmentReservation.UserEmail,
                apartmentReservation.UserPhone,
                apartmentReservation.UserAddress
                );
        }

        public override void InsertApartmentReview(ApartmentReview apartmentReivew)
        {
            apartmentReivew.Guid = Guid.NewGuid();
            apartmentReivew.CreatedAt = DateTime.Now;
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertApartmentReview),
                apartmentReivew.Guid, 
                apartmentReivew.CreatedAt,
                apartmentReivew.ApartmentId,
                apartmentReivew.UserId,
                apartmentReivew.Details,
                apartmentReivew.Stars);
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
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertTag), tag.Guid, tag.CreatedAt, tag.TypeId, tag.Name, tag.NameEng);
        }

        public override void InsertTaggedApartment(TaggedApartment taggedApartment)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertTaggedApartment), taggedApartment.Guid, taggedApartment.ApartmentId, taggedApartment.TagId);
        }

        public override void InsertTagType(TagType tagType)
        {
            throw new NotImplementedException();
        }

        //Also addes role "user" via SQL procedure
        public override Task InsertUser(User user)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(InsertUser),
                user.Guid,
                user.CreatedAt,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                user.Address,
                user.PasswordHash
                );
            return Task.CompletedTask;
        }

        public override Apartment LoadApartmentById(int id)
        {
            var apartment = this.LoadApartmentByIdRaw(id);
            var pictures = this.LoadApartmentPicturesByApartmentId(apartment.Id);
            var status = this.LoadApartmentStatusByIdRaw(apartment.StatusId);
            var city = this.LoadCityByIdRaw(apartment.CityId);
            var tags = this.LoadTagsByApartmentId(apartment.Id);
            var reviews = this.LoadApartmentReviewsByApartmentId(apartment.Id);
            apartment.Pictures = new List<ApartmentPicture>(pictures);
            apartment.Status = status;
            apartment.City = city;
            apartment.Tags = new List<Tag>(tags);
            apartment.Reviews = new List<ApartmentReview>(reviews);

            return apartment;
        }

        public override IList<ApartmentReview> LoadApartmentReviewsByApartmentId(int id)
        {
            IList<ApartmentReview> apartmentReviews = new List<ApartmentReview>();

            var tblApartmentReviews = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentReviewsByApartmentId), id).Tables[0];
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
                        UserId = (int)row[nameof(ApartmentReview.UserId)],
                        Stars = (int)row[nameof(ApartmentReview.Stars)],
                    }
                );
            }

            foreach (var review in apartmentReviews)
            {
                review.User = this.LoadUserById(review.UserId);
            }

            return apartmentReviews;
        }

        public override ApartmentOwner LoadApartmentOwnerById(int id)
        {
            var apartmentOwner = this.LoadApartmentOwnerByIdRaw(id);
            var apartments = this.LoadApartmentsByOwnerId(apartmentOwner.Id);

            apartmentOwner.Apartments = new List<Apartment>(apartments);

            return apartmentOwner;
        }

        public override IList<ApartmentOwner> LoadApartmentOwners()
        {
            return this.LoadApartmentOwnersRaw();
        }

        public override ApartmentPicture LoadApartmentPictureById(int id)
        {
            return this.LoadApartmentPictureByIdRaw(id);
        }

        public override IList<ApartmentPicture> LoadApartmentPictures()
        {
            return this.LoadApartmentPicturesRaw();
        }

        public override IList<ApartmentPicture> LoadApartmentPicturesByApartmentId(int id)
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();

            var tblApartmentPictures = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentPicturesByApartmentId), id).Tables[0];
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

        public override ApartmentReservation LoadApartmentReservationById(int id)
        {
            var reservation = this.LoadApartmentReservationByIdRaw(id);
            if (reservation.UserId != null)
            {
                int userId = (int)reservation.UserId;
                var user = this.LoadUserByIdRaw(userId);
                reservation.User = user;
            }
            else
            {
                var tempUser = new User();
                tempUser.Address = reservation.UserAddress;
                tempUser.Email = reservation.UserEmail;
                tempUser.UserName = reservation.UserName;
                tempUser.PhoneNumber = reservation.UserPhone;
                reservation.User = tempUser;
            }
            var apartment = this.LoadApartmentByIdRaw(reservation.ApartmentId);

            reservation.Apartment = apartment;

            return reservation;
        }

        public override IList<ApartmentReservation> LoadApartmentReservations()
        {
            return this.LoadApartmentReservationsRaw();
        }

        public override ApartmentReview LoadApartmentReviewById(int id)
        {
            var review = this.LoadApartmentReviewByIdRaw(id);
            var apartment = this.LoadApartmentByIdRaw(review.ApartmentId);
            var user = this.LoadUserByIdRaw(review.UserId);

            review.Apartment = apartment;
            review.User = user;

            return review;
        }

        public override IList<ApartmentReview> LoadApartmentReviews()
        {
            return this.LoadApartmentReviewsRaw();
        }

        public override IList<Apartment> LoadApartments()
        {
            return this.LoadApartmentsRaw();
        }
        public override IList<Apartment> LoadApartments(params Predicate<Apartment>[] filters)
        {
            var apartments = this.LoadApartmentsRaw();
            var filteredApartments = new List<Apartment>();
            foreach (var apartment in apartments)
            {
                var fullApartment = this.LoadApartmentById(apartment.Id);
                bool valid = true;
                foreach (var filter in filters)
                {
                    if (!filter(fullApartment))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    filteredApartments.Add(fullApartment);
            }
            return filteredApartments;
        }

        public override IList<Apartment> LoadApartmentsByOwnerId(int id)
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentsByOwnerId), id).Tables[0];
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

        public override IList<ApartmentStatus> LoadApartmentStatus()
        {
            return this.LoadApartmentStatusRaw();
        }

        public override ApartmentStatus LoadApartmentStatusById(int id)
        {
            return this.LoadApartmentStatusByIdRaw(id); //Extra information not necesarry
        }

        public override IList<City> LoadCities()
        {
            return this.LoadCitiesRaw();
        }

        public override City LoadCitiyById(int id)
        {
            return this.LoadCityByIdRaw(id);
        }

        public override Tag LoadTagById(int id)
        {
            return this.LoadTagByIdRaw(id);
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
            return this.LoadTagsRaw();
        }

        public override IList<Tag> LoadTagsByApartmentId(int id)
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadTagsByApartmentId), id).Tables[0];
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

        public override IList<Tuple<Tag, int>> LoadTagsCounted()
        {
            var taggedApartments = this.LoadTaggedApartmentsRaw();
            Dictionary<Tag, int> dict = new Dictionary<Tag, int>();
            foreach (var taggedApartment in taggedApartments)
            {
                var tempTag = this.LoadTagByIdRaw(taggedApartment.TagId);
                if (!dict.Keys.Contains(tempTag))
                    dict.Add(tempTag, 1);
                else
                    dict[tempTag]++;
            }
            var allTags = this.LoadTagsRaw();
            foreach (var tag in allTags)
            {
                if (!dict.Keys.Contains(tag))
                    dict.Add(tag, 0);
            }
            return dict.Select(x => new Tuple<Tag, int>(x.Key, x.Value)).ToList();
        }

        public override TagType LoadTagTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<TagType> LoadTagTypes()
        {
            return this.LoadTagTypesRaw();
        }

        public string LoadUserRoleByRoleId(int roleId)
        {
            IList<string> roles = new List<string>();

            var tblRoles = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUserRoleByRoleId), roleId).Tables[0];
            foreach (DataRow row in tblRoles.Rows)
            {
                roles.Add((string)row["Name"]);
            }
            return roles[0];
        }

        public IList<string> LoadUserRolesByUserId(int userId)
        {
            IList<int> roleIds = new List<int>();
            var tblRoles = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadUserRolesByUserId), userId).Tables[0];
            foreach (DataRow row in tblRoles.Rows)
            {
                roleIds.Add((int)row["RoleId"]);
            }
            IList<string> roles = new List<string>();
            foreach (var roleId in roleIds)
            {
                roles.Add(this.LoadUserRoleByRoleId(roleId));
            }
            return roles;
        }

        public override User LoadUserById(int id)
        {
            var user = this.LoadUserByIdRaw(id);
            user.Roles = this.LoadUserRolesByUserId(int.Parse(user.Id));
            return user;
        }

        public override IList<User> LoadUsers()
        {
            var users = this.LoadUsersRaw();
            foreach (var user in users)
            {
                user.Roles = this.LoadUserRolesByUserId(int.Parse(user.Id));
            }
            return users;
        }

        public override void UpdateApartment(Apartment apartment, IList<ApartmentPicture> picturesToRemove)
        {
            int id = apartment.Id;
            var tagsFromDatabase = this.LoadTagsByApartmentId(apartment.Id);
            var currentTags = apartment.Tags;

            if (tagsFromDatabase.Count.Equals(0) || !currentTags.Equals(tagsFromDatabase))
            {
                IList<Tag> tagsToDelete = tagsFromDatabase.Except(currentTags).ToList();
                IList<Tag> tagsToAdd = currentTags.Except(tagsFromDatabase).ToList();

                foreach (Tag tag in tagsToDelete)
                    this.DeleteTaggedApartment(new TaggedApartment { ApartmentId = apartment.Id, TagId = tag.Id });
                foreach (Tag tag in tagsToAdd)
                    this.InsertTaggedApartment(new TaggedApartment { Guid = Guid.NewGuid(), ApartmentId = apartment.Id, TagId = tag.Id });
            }

            foreach (ApartmentPicture picture in apartment.Pictures)
            {
                picture.ApartmentId = apartment.Id;
                if (picture.Id == 0)
                    this.InsertApartmentPicture(picture);
                else
                    this.UpdateApartmentPicture(picture);
            }
            foreach (ApartmentPicture picture in picturesToRemove)
            {
                this.DeleteApartmentPicture(picture.Guid);
            }

            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(UpdateApartment),
                apartment.Id,
                apartment.OwnerId,
                apartment.StatusId,
                apartment.CityId,
                apartment.Address,
                apartment.Name,
                apartment.NameEng,
                apartment.Price,
                apartment.MaxAdults,
                apartment.MaxChildren,
                apartment.TotalRooms,
                apartment.BeachDistance);
        }

        private void UpdateApartmentPicture(ApartmentPicture picture)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(UpdateApartmentPicture), picture.Guid, picture.Name, picture.IsRepresentative);
        }

        public override IList<string> LoadApartmentNames()
        {
            IList<string> apartmentNames = new List<string>();

            var tblNames = SqlHelper.ExecuteDataset(APARTMENS_CS, nameof(LoadApartmentNames)).Tables[0];
            foreach (DataRow row in tblNames.Rows)
            {
                apartmentNames.Add((string)row[nameof(Apartment.NameEng)]);
            }

            return apartmentNames;
        }

        public override void GenerateApartmentReservation(ApartmentReservation apartmentReservation)
        {
            this.InsertApartmentReservation(apartmentReservation);
            this.UpdateApartmentAsReserved(apartmentReservation.ApartmentId);

        }

        private void UpdateApartmentAsReserved(int apartmentId)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(UpdateApartmentAsReserved), apartmentId);
        }
    }
}
