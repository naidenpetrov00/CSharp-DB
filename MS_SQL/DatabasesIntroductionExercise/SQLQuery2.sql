CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	UserName NVARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL
)

DROP TABLE Users

INSERT INTO Users(Username, [Password],ProfilePicture, LastLoginTime, IsDeleted) VALUES
	('Pesho', '123', NULL, NULL, 0),
	('Gosho', '123',NULL,NULL,0),
	('Ivan', '123',NULL,NULL,0),
	('Test', '123',NULL,NULL,1),
	('Test123', '123',NULL,NULL,1)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0775A46987

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id,Username)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password],ProfilePicture, IsDeleted) VALUES
	('TestTttt', '123', NULL, 1)

SELECT * FROM Users