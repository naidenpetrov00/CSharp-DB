SELECT TOP(30) [CountryName], [Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, [CountryName] ASC

SELECT CountryName, CountryCode, 
CASE WHEN CurrencyCode = 'EUR' THEN 'Euro'
ELSE 'NotEuro'
END AS [Currency]
FROM Countries
ORDER BY CountryName