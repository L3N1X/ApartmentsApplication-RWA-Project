/*
Dodati connection string u web.config

<connectionStrings>
	<add name="cs" connectionString="Server=[IP/Hostname];Database=[Baza_Podataka];Uid=[User];Pwd=[User_Password]" />
</connectionStrings>
*/

USE master
GO
DROP DATABASE IF EXISTS RWA;
GO
CREATE DATABASE RWA;
GO
USE RWA
GO

-- CITIES
CREATE TABLE City (
	IDCity INT NOT NULL IDENTITY,
	Name NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_City PRIMARY KEY (IDCity),
	CONSTRAINT UQ_CityName UNIQUE (Name)
)
GO

-- PROC: LoadCities
CREATE PROC LoadCities
AS
BEGIN
	SELECT * FROM City
END
GO

-- USERS
CREATE TABLE Auth (
	IDAuth INT NOT NULL IDENTITY,
	FName NVARCHAR(50) NOT NULL,
	LName NVARCHAR(50) NOT NULL,
	CityID INT NOT NULL,
	Username NVARCHAR(50) NOT NULL,
	Password NVARCHAR(128) NOT NULL,

	CONSTRAINT PK_Auth PRIMARY KEY (IDAuth),
	CONSTRAINT UQ_Username UNIQUE (Username),
	CONSTRAINT FK_City FOREIGN KEY (CityID) REFERENCES City(IDCity),
)
GO

-- PROC: Login
CREATE PROC AuthUser
	@username NVARCHAR(50),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT A.IDAuth, A.FName, A.LName, A.Username, A.Password, C.IDCity, C.Name FROM Auth AS A INNER JOIN City AS C ON A.CityID=C.IDCity WHERE Username=@username AND Password=@password 
END
GO

-- PROC: LoadUsers
CREATE PROC LoadUsers
AS
BEGIN
	SELECT A.IDAuth, A.FName, A.LName, A.Username, A.Password, C.IDCity, C.Name FROM Auth AS A INNER JOIN City AS C ON A.CityID=C.IDCity
END
GO

-- PROC: SaveUser
CREATE PROC SaveUser
	@fname NVARCHAR(50),
	@lname NVARCHAR(50),
	@username NVARCHAR(50),
	@userID INT
AS
BEGIN
	UPDATE Auth SET FName=@fname, LName=@lname, Username=@username WHERE IDAuth=@userID
END
GO

-- PROC: AddUser
CREATE PROC AddUser
	@fname NVARCHAR(50),
	@lname NVARCHAR(50),
	@cityID INT,
	@username NVARCHAR(50),
	@password NVARCHAR(128)
AS
BEGIN
	INSERT INTO Auth (FName, LName, CityID, Username, Password) VALUES (@fname, @lname, @cityID, @username, @password);
END
GO

-- INSERT
INSERT INTO City (Name) VALUES ('Zagreb');
INSERT INTO City (Name) VALUES ('Rijeka');
INSERT INTO City (Name) VALUES ('Split');

/*
USER: pero
PW: 123

USER: demo
PW: 123
*/
-- INSERT
INSERT INTO Auth (FName, LName, CityID, Username, Password) VALUES ('Pero', 'Perić', 1, 'pero', '3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2');
INSERT INTO Auth (FName, LName, CityID, Username, Password) VALUES ('Demo', 'Demić', 2, 'demo', '3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3EEE4C047E7AB1C1EB8B85103E3BE7BA613B31BB5C9C36214DC9F14A42FD7A2FDB84856BCA5C44C2');