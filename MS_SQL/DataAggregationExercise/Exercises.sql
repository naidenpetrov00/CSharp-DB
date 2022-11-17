-- Problem 1. Records’ Count
SELECT 
	COUNT(Id) as [Count]
FROM WizzardDeposits

-- Problem 2. Longest Magic Wand
SELECT
	MAX(MagicWandSize) as [LongestMagicWand]
FROM WizzardDeposit

-- Problem 3. Longest Magic Wand per Deposit Groups
SELECT
	w.DepositGroup,
	MAX(w.MagicWandSize) as [LongestMagicWand]
FROM WizzardDeposits as w
GROUP BY w.DepositGroup

-- Problem 7. Deposits Filter
SELECT 
	w.DepositGroup,
	SUM(w.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount) < 150000
ORDER BY [TotalSum] DESC

-- Problem 8. Deposit Charge
SELECT
	w.DepositGroup,
	w.MagicWandCreator,
	MIN(w.DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup ASC

-- Problem 9. Age Groups
SELECT 
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END AS [AgeGroup],
COUNT(*) AS [WizardCount]
FROM WizzardDeposits
GROUP BY  
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END

-- Problem 12. * Rich Wizard, Poor Wizard
SELECT SUM([Difference]) AS SumDifference FROM (SELECT FirstName AS [Host Wizard],
	   DepositAmount AS [Host Wizard Deposit],
	   LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
	   LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
	   DepositAmount -  LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS DiffTable