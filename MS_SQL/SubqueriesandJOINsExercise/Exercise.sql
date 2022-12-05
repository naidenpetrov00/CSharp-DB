-- Problem 4. Employee Departments	
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees as e
	JOIN Departments as d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID
--

-- Problem 5. Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees as e
	LEFT JOIN EmployeesProjects as ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID
--

-- Problem 6. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees as e
	JOIN Departments as d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate
--

-- Problem 7. Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name], p.StartDate, p.EndDate
FROM Employees as e
 JOIN EmployeesProjects  as ep ON ep.EmployeeID = e.EmployeeID
 JOIN Projects as p ON p.ProjectID = ep.ProjectID
 WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
 ORDER BY e.EmployeeID
 --

 -- Problem 8. Employee 24
 SELECT e.EmployeeID, 
		e.FirstName, 
		p.[Name], 
		IIF(p.StartDate > '12.31.2004', p.[Name], NULL)
FROM Employees AS e
	JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24
--

-- Problem 10. Employee Summary
SELECT TOP(50) e.EmployeeID, e.FirstName, mng.FirstName, d.[Name]
FROM Employees AS e
	JOIN Employees AS mng ON  mng.EmployeeID = e.ManagerID
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID
--

USE Geography

-- Problem 12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC
--

-- Problem 13. Count Mountain Ranges
SELECT mc.CountryCode , COUNT(MountainId)
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('US', 'RU', 'BG')
GROUP BY CountryCode
--

-- Problem 15. *Continents and Currencies
SELECT c.ContinentCode, 
		c.CurrencyCode, 
		COUNT(c.CurrencyCode), 
		ROW_NUMBER() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode))
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1
ORDER BY c.ContinentCode, c.CurrencyCode