ALTER FUNCTION udf_ProcessText(@text NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN
	RETURN @text + 'Text'
END
GO

SELECT dbo.udf_ProcessText(e.FirstName)
FROM Employees AS e 
--

CREATE FUNCTION udf_GetSalaryLevel(@salary DECIMAL)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)

	IF(@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF(@salary <= 50000)
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

SELECT FirstName,LastName, dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees
--

CREATE OR ALTER PROC usp_OldestEmplyees(@totalEmployees INT, @maxSalary INT = 1000000)
AS
	SELECT TOP(@totalEmployees) *
	FROM Employees
	WHERE Salary < @maxSalary
	ORDER BY HireDate DESC
GO
 
EXEC dbo.usp_OldestEmplyees 10, 100000
--

CREATE OR ALTER PROC usp_InsertProject(@employeeId INT, @projectId INT)
AS
BEGIN
	DECLARE @totalProjects INT
	SET @totalProjects =
	(
	SELECT COUNT(*)
	FROM EmployeesProjects AS ep
	WHERE ep.EmployeeID = @employeeId
	)

	IF (@totalProjects > 3)
	BEGIN
		THROW 50001, 'Employees cannot have more than 3 project.', 1
	END

	INSERT INTO EmployeesProjects
	VALUES (@employeeId, @projectId
END
GO

EXEC dbo.usp_InsertProject 1, 3
EXEC dbo.usp_InsertProject 2, 1