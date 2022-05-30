USE RwaApartmani
GO
/*Bulk select procedures*/
CREATE PROCEDURE LoadApartments
AS
	SELECT * FROM Apartment WHERE Apartment.DeletedAt IS NULL
GO
CREATE PROCEDURE LoadApartmentOwners
AS
	SELECT * FROM ApartmentOwner 
GO
CREATE PROCEDURE LoadApartmentPictures
AS
	SELECT * 
	FROM ApartmentPicture 
	WHERE ApartmentPicture.DeletedAt IS NULL

GO
CREATE PROCEDURE LoadApartmentReservations
AS
	SELECT *
	FROM ApartmentReservation
GO
CREATE PROCEDURE LoadApartmentReviews
AS
	SELECT *
	FROM ApartmentReview
GO
CREATE PROCEDURE LoadApartmentStatus
AS
	SELECT *
	FROM ApartmentStatus
GO
CREATE PROCEDURE LoadCities
AS
	SELECT *
	FROM City
GO
CREATE PROCEDURE LoadTags
AS
	SELECT *
	FROM Tag
GO
CREATE PROCEDURE LoadTaggedApartments
AS
	SELECT *
	FROM TaggedApartment
GO
CREATE PROCEDURE LoadTagTypes
AS
	SELECT *
	FROM TagType
GO
CREATE PROCEDURE LoadUsers
AS
	SELECT *
	FROM AspNetUsers
	WHERE AspNetUsers.DeletedAt IS NULL
GO
/*Id select Procedures*/
CREATE PROCEDURE LoadApartmentById
@Id INT 
AS
	SELECT * FROM Apartment WHERE Apartment.Id = @Id
GO
CREATE PROCEDURE LoadApartmentOwnerById
@Id INT
AS
	SELECT * FROM ApartmentOwner WHERE ApartmentOwner.Id = @Id
GO
CREATE PROCEDURE LoadApartmentPictureById
@Id INT 
AS
	SELECT * FROM ApartmentPicture WHERE ApartmentPicture.Id = @Id
GO
CREATE PROCEDURE LoadApartmentReservationById
@Id INT
AS 
	SELECT * FROM ApartmentReservation WHERE ApartmentReservation.Id = @Id
GO
CREATE PROCEDURE LoadApartmentReviewById
@Id INT
AS
	SELECT * FROM ApartmentReview WHERE ApartmentReview.Id = @Id
GO
CREATE PROCEDURE LoadApartmentStatusById
@Id INT
AS
	SELECT * FROM ApartmentReview WHERE ApartmentReview.Id = @Id
GO
CREATE PROCEDURE LoadCitiyById
@Id INT
AS
	SELECT * FROM City WHERE City.Id = @Id
GO
CREATE PROCEDURE LoadTagById
@Id	INT
AS
	SELECT * FROM Tag WHERE Tag.Id = @Id
GO
CREATE PROCEDURE LoadTaggedApartmentById
@Id INT
AS
	SELECT * FROM TaggedApartment WHERE TaggedApartment.Id = @Id
GO
CREATE PROCEDURE LoadTagTypeById
@Id INT
AS
	SELECT * FROM TagType WHERE TagType.Id = @Id
GO
CREATE PROCEDURE LoadUserById
@Id INT
AS
	SELECT * FROM AspNetUsers WHERE AspNetUsers.Id = @Id
