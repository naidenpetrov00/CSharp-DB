--
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	AND d.[Name] IN ('Sales', 'Finance')
WHERE e.HireDate > '1999-01-01'
ORDER BY e.HireDate

--
SELECT e.FirstName, e.LastName
FROM Employees AS e
	JOIN Addresses as a ON e.AddressID = a.AddressID
	JOIN Towns as t ON a.TownID = t.[Name] 

--
SELECT MIN(dt.AverageSalary) MinAverageSalary
FROM
	(SELECT 
	 	 AVG(Salary) as AverageSalary,
	 	 DepartmentID
	 FROM Employees 
	 GROUP BY DepartmentID) as dt
