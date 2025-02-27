--###############################################################################################################
--# Allow users to search based off any search criteria passed in
--#
--# HG 02/25/2025 Initial Creation
--#
--###############################################################################################################
CREATE PROCEDURE dbo.usp_VehicleSearch (
	@Color NVARCHAR(MAX) = NULL,
	@MinYear INT = 0,
	@MaxYear INT = 9999,
	@Make NVARCHAR(MAX) = NULL,
	@MinPrice DECIMAL(10,2) = 0.00,
	@MaxPrice DECIMAL(10,2) = 99999.00,
	@HasSunroof BIT = NULL,
	@IsFourWheelDrive BIT = NULL,
	@HasLowMiles BIT = NULL,
	@HasPowerWindows BIT = NULL,
	@HasNavigation BIT = NULL,
	@HasHeatedSeats BIT = NULL
)
AS
SELECT c.*
, cl.ColorName
, m.MakeName
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