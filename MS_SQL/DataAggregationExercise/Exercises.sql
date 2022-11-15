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