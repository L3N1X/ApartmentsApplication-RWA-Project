USE RwaApartmani
CREATE PROCEDURE LoadApartments
AS
	SELECT * FROM Apartment WHERE Apartment.DeletedAt IS NULL
GO
CREATE PROCEDURE LoadApartmentOwners
AS
	SELECT * FROM ApartmentOwner 