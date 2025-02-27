CREATE TABLE [dbo].[Cars] (
    [CarID]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [MakeID]           INT              NOT NULL,
    [Year]             INT              NULL,
    [ColorID]          INT              NOT NULL,
    [Price]            DECIMAL (10, 2)  NOT NULL,
    [HasSunroof]       BIT              NOT NULL,
    [IsFourWheelDrive] BIT              NOT NULL,
    [HasLowMiles]      BIT              NOT NULL,
    [HasPowerWindows]  BIT              NOT NULL,
    [HasNavigation]    BIT              NOT NULL,
    [HasHeatedSeats]   BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([CarID] ASC),
    CHECK ([Price]>=(0)),
    CHECK ([Year]>=(1886)),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Color] ([ColorID]),
    FOREIGN KEY ([MakeID]) REFERENCES [dbo].[Make] ([MakeID])
);

