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
ALTER PROCEDURE LoadApartmentStatusById
@Id INT
AS
	SELECT * FROM ApartmentStatus WHERE ApartmentStatus.Id = @Id
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
/*Special select procedures*/
GO
CREATE PROCEDURE LoadTagsByApartmentId
@Id INT
AS
	SELECT t.Id, t.Guid, t.CreatedAt, t.Name, t.NameEng, t.TypeId
	FROM Tag as t
	INNER JOIN TaggedApartment as ta ON ta.TagId = t.Id
	WHERE ta.ApartmentId = @Id
GO
CREATE PROCEDURE LoadApartmentPicturesByApartmentId
@Id INT
AS
	SELECT * 
	FROM ApartmentPicture 
	WHERE ApartmentPicture.ApartmentId = @Id
GO
CREATE PROCEDURE LoadApartmentsByOwnerId
@Id INT
AS
	SELECT *
	FROM Apartment
	WHERE Apartment.OwnerId = @Id
/*Delete procedures*/
GO
CREATE PROCEDURE DeleteApartment
@Id INT
AS
	UPDATE Apartment
	SET Apartment.DeletedAt = GETDATE()
	WHERE Apartment.Id = @Id
GO
CREATE PROCEDURE DeleteApartmentPicture
@Id INT
AS 
	DELETE ApartmentPicture
	WHERE ApartmentPicture.Id = @Id
Go
CREATE PROCEDURE DeleteTag
@Id INT
AS 
	DELETE Tag
	WHERE Tag.Id = @Id
GO
CREATE PROCEDURE DeleteTaggedApartment
@Id INT
AS 
	DELETE TaggedApartment
	WHERE TaggedApartment.Id = @Id
GO
CREATE PROCEDURE DeleteUser
@Id INT
AS 
	UPDATE AspNetUsers
	SET AspNetUsers.DeletedAt = GETDATE()
	WHERE AspNetUsers.Id = @Id
GO

SELECT * FROM ApartmentStatus
SELECT * FROM ApartmentReview
SELECT * FROM Apartment
SELECT * FROM ApartmentPicture
SELECT * FROM TaggedApartment
SELECT * FROM City
