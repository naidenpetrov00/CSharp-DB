ALTER FUNCTION udf_ProcessText(@text NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN
	RETURN @text + 'Text'
END

SELECT dbo.udf_ProcessText(e.FirstName)
FROM Employees AS e 