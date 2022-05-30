using Microsoft.ApplicationBlocks.Data;
using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
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
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteApartment), id);
        }

        public override void DeleteApartmentPicture(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteApartmentPicture), id);
        }

        public override void DeleteTag(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTag), id);
        }

        public override void DeleteTaggedApartment(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteTaggedApartment), id);
        }

        public override void DeleteUser(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENS_CS, nameof(DeleteUser), id);
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
            var apartment = this.LoadApartmentByIdRaw(id);
            var pictures = this.LoadApartmentPicturesByApartmentId(apartment.Id);

            apartment.Pictures = new List<ApartmentPicture>(pictures);

            return apartment;
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
                        //Base64Content = (string)row[nameof(ApartmentPicture.Base64Content)],
                        IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)],
                        Path = (string)row[nameof(ApartmentPicture.Path)],
                    }
                );
            }

            return apartmentPictures;
        }

        public override ApartmentReservation LoadApartmentReservationById(int id)
        {
            var reservation = this.LoadApartmentReservationByIdRaw(id);
            if(reservation.UserId != null)
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
            var apartments = this.LoadApartmentsRaw();
            throw new NotImplementedException();
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
