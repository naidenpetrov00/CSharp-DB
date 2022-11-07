--Hide payment number
CREATE VIEW v_PublicPaymentsInfo AS
SELECT 
	CustomerID,
	FirstName,
	LastName,
	CONCAT(SUBSTRING(PaymentNumber,1,6), REPLICATE('*', LEN(PaymentNumber) - 6)) AS PaymentNumber
FROM Customers

GO

SELECT * FROM v_PublicPaymentsInfo

-- CHARINDEX - locates s specific pattern
SELECT CHARINDEX('is', 'This is long text')

-- STUFF - insert substring in specific position
SELECT STUFF('This is a bad idea', 11, 3, 'good')	

-- FORMAT - returns value formatted with the specified format
SELECT FORMAT(67.23, 'C', 'bg-BG')

-- Problem Pallets
SELECT 
	[NAME], 
	 CEILING(CEILING(CAST(Quantity AS float)/ BoxCapacity) / PalletCapacity) AS Pallets
FROM Products

-- DATEPART - exctract a segment from a date as an int
SELECT 
	DATEPART(WEEK, '2022-12-31')