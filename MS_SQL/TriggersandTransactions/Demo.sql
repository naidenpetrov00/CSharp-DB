-- Transaction demo
CREATE OR ALTER PROC usp_AddProjectToEmployee (@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects
	VALUES (@employeeId, @projectId)

	DECLARE @projectsForEmployee INT
	SET @projectsForEmployee =
	(
		SELECT COUNT(*)
		FROM EmployeesProjects
		WHERE EmployeeID = @employeeId
	)

	IF(@projectsForEmployee > 5)
	BEGIN
		ROLLBACK
		RAISERROR('Too many projects for employee',16,1)
		RETURN
	END
COMMIT

GO

EXEC usp_AddProjectToEmployee 1, 2
--

-- Trigger
CREATE OR ALTER TRIGGER tr_NoEmptyTownsNames ON Towns FOR UPDATE
AS
BEGIN
	IF(EXISTS(
		SELECT * FROM inserted
		WHERE Name IS NULL OR LEN(NAME) < 2))
	BEGIN
		ROLLBACK
		RAISERROR('Town names must have at least 2 symbols', 16, 1)
		RETURN
	END
END 

GO

UPDATE Towns
SET Name = 'A'
WHERE TownID = 2 
--

CREATE OR ALTER TRIGGER tr_SetUpdateOnDate ON Employees FOR UPDATE
AS
BEGIN
	UPDATE e
	SET e.UpdatedOn = GETDATE()
	FROM Employees AS e
	JOIN inserted AS i ON i.EmployeeId = e.EmployeeId
	
END 

GO

UPDATE Employees
SET FirstName = 'Ivan'
WHERE EmployeeID = 11  
--