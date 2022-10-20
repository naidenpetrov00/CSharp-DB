CREATE DATABASE Softuni

USE Softuni

CREATE TABLE Employes(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(8, 2) NOT NULL,
)

INSERT INTO Employes(FirstName, MiddleName, LastName, Salary) VALUES
	('Pesho', NULL, 'Peshov', 2550.50),
	('Gosho', NULL, 'Goshov', 1650.35),
	('Ivan', NULL, 'Ivan', 3150.45)

SELECT * FROM Employes

UPDATE Employes
SET Salary += 1000