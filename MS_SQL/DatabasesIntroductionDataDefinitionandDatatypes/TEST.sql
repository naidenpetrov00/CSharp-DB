SELECT * FROM Students

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
)

INSERT INTO Students (FirstName,LastName) VALUES
('test','test')

DROP TABLE Students			