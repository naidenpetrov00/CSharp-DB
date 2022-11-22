USE Blog

SELECT c.Id, c.Text, a.FirstName, a.LastName, ar.Title
  FROM Comments c
  JOIN Authors a
  ON c.ArticleId = a.Id
  JOIN Articles ar
  ON c.ArticleId = ar.Id

USE Geography

SELECT p.PeakName, m.MountainRange, p.Elevation
  FROM Peaks p
  JOIN Mountains m
  ON p.MountainId = m.Id
  WHERE m.MountainRange = 'Rila'
  ORDER BY p.Elevation DESC