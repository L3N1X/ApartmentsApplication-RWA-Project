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
