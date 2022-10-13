CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
)

ALTER TABLE Students
ADD Balance DECIMAL(15,3)

INSERT INTO Students (FirstName,LastName, Balance) VALUES
('test','test', 345.12345)

ALTER TABLE Students 
ADD CONSTRAINT CHK_StudentFirstName CHECK (LEN(FirstName)>=3)

SELECT * FROM Students
SELECT LEN(FirstName) FROM Students