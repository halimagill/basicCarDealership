--CREATE PROCEDURE usp_VehicleSearch(

--Declare @IDs IntList;
--Insert Into @IDs Select Id From dbo.{TableThatHasIds}
--Where Id In (111, 222, 333, 444)
--Exec [dbo].[GetFooByIds] @IDs

DECLARE
--@ColorID [IntList] ReadOnly,
@Color NVARCHAR(MAX) = 'Grey,Black,White',
@MinYear INT = 0,
@MaxYear INT = 9999,
--Color 
@Make NVARCHAR(MAX) = 'Toyota,Chevy',
@MinPrice DECIMAL(10,2) = 0.00,
@MaxPrice DECIMAL(10,2) = 17000.00,
@HasSunroof BIT = NULL,
@IsFourWheelDrive BIT = NULL,
@HasLowMiles BIT = NULL,
@HasPowerWindows BIT = 1,
@HasNavigation BIT = NULL,
@HasHeatedSeats BIT = NULL
--)
--AS
SELECT c.*
, cl.*
, m.*
FROM dbo.Cars c
INNER JOIN dbo.Color cl
ON c.ColorID = cl.ColorID
INNER JOIN dbo.Make m
ON c.MakeID = m.MakeID
WHERE (cl.ColorName IN (SELECT * FROM string_split(@Color, ',')) OR @Color IS NULL)
AND (m.MakeName IN (SELECT * FROM string_split(@Make, ',')) OR @Make IS NULL)
AND (c.Price BETWEEN @MinPrice AND @MaxPrice)
AND (c.HasSunroof = @HasSunroof OR @HasSunroof IS NULL)
AND (c.IsFourWheelDrive = @IsFourWheelDrive OR @IsFourWheelDrive IS NULL)
AND (c.HasLowMiles = @HasLowMiles OR @HasLowMiles IS NULL)
AND (c.HasPowerWindows = @HasPowerWindows OR @HasPowerWindows IS NULL)
AND (c.HasNavigation = @HasNavigation OR @HasNavigation IS NULL)
AND (c.HasHeatedSeats = @HasHeatedSeats OR @HasHeatedSeats IS NULL)

--Color 
-- Make
--No Model??
--Price range
-- HasSunroof
--IsFourWheelDrive
--HasLowMiles
--HasPowerWindows
--HasNavigation
--HasHeatedSeats


/*
4 wheel drive

low miles -- in the table

power windows -- in the table

navigation
*/

----------------------
--Execute Proc
EXEC dbo.usp_VehicleSearch @Color = 'Gray', --MISSPELL ON PURPOSE
	@MinYear = 0,
	@MaxYear = 9999,
	@Make = NULL,
	@MinPrice = 0.00,
	@MaxPrice = 99999.99,
	@HasSunroof = NULL,
	@IsFourWheelDrive = NULL,
	@HasLowMiles = NULL,
	@HasPowerWindows = NULL,
	@HasNavigation = NULL,
	@HasHeatedSeats = NULL


--Should get everything with no params
dbo.usp_VehicleSearch