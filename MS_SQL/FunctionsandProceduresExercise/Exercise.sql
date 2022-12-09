USE SoftUni

--Employees with Salary Above 35000
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees AS e
	WHERE e.Salary > 35000
END
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000
--

--Employees with Salary Above Number
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber(@salaryLevel DECIMAL(18, 4))	
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees AS e
	WHERE e.Salary >= @salaryLevel
END
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100
--

--Town Names Starting With
CREATE OR ALTER PROC usp_GetTownsStartingWith(@startingString NVARCHAR(10))
AS
BEGIN
	SELECT t.[Name]
	FROM Towns AS t
	WHERE t.[Name] LIKE @startingString+'%'
END
GO

EXEC dbo.usp_GetTownsStartingWith b
--

--Employees from Town
CREATE OR ALTER PROC usp_GetEmployeesFromTown(@townName NVARCHAR(10))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] LIKE @townName
END
GO

EXEC dbo.usp_GetEmployeesFromTown Sofia
--

--Salary Level Function
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS	NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)

	IF(@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF(@salary < 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END
GO

SELECT FirstName,LastName, Salary, dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees