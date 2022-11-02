SELECT [Name] FROM Departments

SELECT FirstName + '.' + LastName + '@softuni.bg' 
AS	   [Full Email Address]
FROM   Employees

SELECT DISTINCT [Salary]
FROM            Employees

SELECT CONCAT(FirstName, ' ',  MiddleName + ' ', LastName)
AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
 
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName
AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

GO
CREATE VIEW V_EmployeeNameJobTitle
AS 
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName
AS [Full Name], JobTitle
AS [Job Title]
FROM Employees
GO

SELECT *
FROM V_EmployeeNameJobTitle

UPDATE Employees
SET Salary *= 12
WHERE 
JobTitle = 'Tool Designer' OR 
JobTitle= 'Marketing Assistant' OR
JobTitle= 'Marketing Manager'

UPDATE Employees
SET Salary *= 12
WHERE DepartmentID IN (1,2,4,11)