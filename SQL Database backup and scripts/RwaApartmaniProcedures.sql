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
CREATE PROCEDURE LoadApartmentReviewsByApartmentId
@ApartmentId INT
AS
	SELECT *
	FROM ApartmentReview
	WHERE ApartmentId = @ApartmentId
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
CREATE PROCEDURE DeleteTag
@Id INT
AS 
	DELETE Tag
	WHERE Tag.Id = @Id
GO
ALTER PROCEDURE DeleteTaggedApartment
@ApartmentId INT,
@TagId INT
AS 
	DELETE TaggedApartment
	WHERE ApartmentId = @ApartmentId
	AND TagId = @TagId
GO
CREATE PROCEDURE DeleteUser
@Id INT
AS 
	UPDATE AspNetUsers
	SET AspNetUsers.DeletedAt = GETDATE()
	WHERE AspNetUsers.Id = @Id
GO
/*Create procedures*/
CREATE PROCEDURE InsertTag
@Guid UNIQUEIDENTIFIER,
@CreatedAt DATETIME,
@TypeId INT,
@Name NVARCHAR(250),
@NameEng NVARCHAR(250)
AS
	INSERT INTO Tag (Guid, CreatedAt, TypeId, Name, NameEng)
	VALUES (@Guid, @CreatedAt, @TypeId, @Name, @NameEng)
GO

CREATE PROCEDURE InsertApartment
@Guid UNIQUEIDENTIFIER,
@CreatedAt DATETIME,
@OwnerId INT,
@StatusId INT,
@CityId INT,
@Address NVARCHAR(250),
@Name NVARCHAR(250),
@NameEng NVARCHAR(250),
@Price MONEY,
@MaxAdults INT,
@MaxChildren INT,
@TotalRooms INT,
@BeachDistance INT
AS
	INSERT INTO Apartment (Guid, CreatedAt, OwnerId, StatusId, CityId, Address, Name, NameEng, Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance, TypeId)
	VALUES(@Guid, @CreatedAt, @OwnerId, @StatusId, @CityId, @Address, @Name, @NameEng, @Price, @MaxAdults, @MaxChildren, @TotalRooms, @BeachDistance, 999)

GO

CREATE PROCEDURE InsertTaggedApartment
@Guid UNIQUEIDENTIFIER,
@ApartmentId INT,
@TagId INT
AS
	INSERT INTO TaggedApartment (Guid, ApartmentId, TagId)
	VALUES(@Guid, @ApartmentId, @TagId)

GO

CREATE PROCEDURE InsertApartmentPicture
@Guid UNIQUEIDENTIFIER,
@CreatedAt DATETIME,
@ApartmentId INT,
@Path NVARCHAR(250),
@Base64Content VARCHAR(MAX),
@Name NVARCHAR(250),
@IsRepresentative BIT
AS
	INSERT INTO ApartmentPicture (Guid, CreatedAt, ApartmentId, Path, Base64Content, Name, IsRepresentative)
	VALUES (@Guid, @CreatedAt, @ApartmentId, @Path, @Base64Content, @Name, @IsRepresentative)
GO

CREATE PROCEDURE InsertApartmentReview
@Guid UNIQUEIDENTIFIER,
@CreatedAt DATETIME,
@ApartmentId INT,
@UserId INT,
@Details NVARCHAR(1000),
@Stars INT
AS
	INSERT INTO ApartmentReview ( Guid, CreatedAt, ApartmentId, UserId, Details, Stars)
	VALUES (@Guid, @CreatedAt, @ApartmentId, @UserId, @Details, @Stars)

GO
CREATE PROCEDURE LoadApartmentIdByGuid
@Guid UNIQUEIDENTIFIER
AS
	SELECT Apartment.Id
	FROM Apartment 
	WHERE Guid = @Guid

CREATE PROCEDURE UpdateApartment
@Id INT,
@OwnerId INT,
@StatusId INT,
@CityId INT,
@Address NVARCHAR(250),
@Name NVARCHAR(250),
@NameEng NVARCHAR(250),
@Price MONEY,
@MaxAdults INT,
@MaxChildren INT,
@TotalRooms INT,
@BeachDistance INT
AS
	UPDATE Apartment
	SET OwnerId = @OwnerId, StatusId = @StatusId, CityId = @CityId, Address = @Address, Name =  @Name, NameEng = @NameEng, Price = @Price, MaxAdults = @MaxAdults, MaxChildren = @MaxChildren, TotalRooms = @TotalRooms, BeachDistance = @BeachDistance
	WHERE Id = @Id


CREATE PROCEDURE DeleteTaggedApartmentByApartmentId
@ApartmentId INT
AS
	DELETE TaggedApartment WHERE ApartmentId = @ApartmentId

GO
CREATE PROCEDURE InsertApartmentReservation
@Guid UNIQUEIDENTIFIER,
@CreatedAt DATETIME,
@ApartmentId INT,
@Details NVARCHAR(1000),
@UserId INT,
@UserName NVARCHAR(250),
@UserEmail NVARCHAR(250),
@UserPhone NCHAR(20),
@UserAddress NVARCHAR(1000)
AS
	INSERT INTO ApartmentReservation (Guid, CreatedAt, ApartmentId, Details, UserId, UserName, UserEmail, UserPhone, UserAddress)
	VALUES (@Guid, @CreatedAt, @ApartmentId, @Details, @UserId, @UserName, @UserEmail, @UserPhone, @UserAddress)
GO

CREATE PROCEDURE DeleteApartmentPicture
@Guid UNIQUEIDENTIFIER
AS
	UPDATE ApartmentPicture
	SET DeletedAt = GETDATE()
	WHERE Guid = @Guid

GO

CREATE PROCEDURE LoadApartmentNames
AS
	SELECT Apartment.NameEng FROM Apartment

GO

CREATE PROCEDURE UpdateApartmentPicture
@Guid UNIQUEIDENTIFIER,
@Name NVARCHAR(250),
@IsRepresentative BIT
AS
	UPDATE ApartmentPicture
	SET Name =  @Name, IsRepresentative = @IsRepresentative
	WHERE Guid = @Guid

USE RwaApartmani

SELECT * FROM TaggedApartment
SELECT * FROM ApartmentStatus
SELECT * FROM TagType
SELECT * FROM ApartmentReview
SELECT * FROM Apartment
SELECT * FROM ApartmentPicture
SELECT * FROM TaggedApartment
SELECT * FROM City


DELETE FROM Apartment WHERE Id = 12
DELETE FROM TaggedApartment WHERE ApartmentId = 12

UPDATE Apartment SET DeletedAt = null WHERE Id = 3

SELECT * FROM Tag WHERE NameEng LIKE 'Wash%'
UPDATE Tag
SET NameEng = 'Washing machine'
WHERE Id = 14

/*1 - Occupied
2 - Reserved
3 - Vacant*/