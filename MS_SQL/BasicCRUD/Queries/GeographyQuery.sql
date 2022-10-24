-- Highest peak
CREATE VIEW v_HighestPeak100 AS
SELECT TOP(100) Elevation
  FROM Peaks
  ORDER BY Elevation DESC

SELECT * FROM v_HighestPeak100

SELECT * 
  FROM Countries
  ORDER BY CountryCode, [Population] DESC