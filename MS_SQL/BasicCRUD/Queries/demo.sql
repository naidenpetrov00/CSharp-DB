SELECT d.Name AS DepartmentName FROM Departments AS d

SELECT FirstName + ' ' + LastName AS [Full Name],
	   JobTitle,
	   Salary
  FROM Employees

SELECT *
  FROM Employees
  WHERE DepartmentID = 1

SELECT *
  FROM Employees
  WHERE Salary BETWEEN 30000 AND 80000
  ORDER BY Salary ASC

SELECT *
  FROM Employees
  WHERE DepartmentID NOT IN (1, 2, 3)

SELECT TOP(5) * 
  FROM Employees
  ORDER BY Salary DESC

  -- Views
CREATE VIEW v_EmployeesSalaryInfo AS
SELECT FirstName + ' ' + LastName AS [Full Name],
       Salary
  FROM Employees

SELECT * FROM v_EmployeesSalaryInfo

INSERT INTO Towns VALUES ('Imeto')

-- Inserting rows into existing table
INSERT INTO Projects (Name, StartDate)
SELECT Name, GETDATE()
       FROM Departments

SELECT * FROM Projects

SELECT FirstName, LastName, JobTitle
  INTO MyFiredEmployees
  FROM Employees

SELECT * FROM MyFiredEmployees