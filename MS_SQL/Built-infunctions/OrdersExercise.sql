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