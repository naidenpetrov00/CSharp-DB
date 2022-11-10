--Problem 1. Find Names of All Employees by First Name
SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'SA%'

--Problem 2. Find Names of All employees by Last Name
SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'

--Problem 3. Find First Names of All Employees
SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN ('3', '10') AND 
       CAST(DATEPART(YEAR, HireDate) AS int) BETWEEN 1995 AND 2050

--Problem 4. Find All Employees Except Engineers
SELECT FirstName, LastName, JobTitle
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5. Find Towns with Name Length
  SELECT [Name]
    FROM Towns
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

--Problem 6. Find Towns Starting With
  SELECT TownID, [Name]
    FROM Towns
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC

--
