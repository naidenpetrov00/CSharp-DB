--Insert
INSERT INTO Planets
VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships
VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)
--

--Update
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id >= 8 AND Id <= 10
--

--Delete
DELETE TOP(3) FROM Journeys

DELETE FROM TravelCards
WHERE JourneyId IN (SELECT TOP(3) Id FROM Journeys)
--