--Problem: Departments total salaries
SELECT 
	e.DepartmentID,
	SUM(e.Salary) as [TotalSalary]
FROM Employees as e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

-- Having clause: Example
SELECT 
	e.DepartmentID,
	SUM(e.Salary) as [TotalSalary]
FROM Employees as e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) >= 15000