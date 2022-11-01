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