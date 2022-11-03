SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1), SUBSTRING(LastName, 1, 1)) AS [Full Name]
FROM     Employees