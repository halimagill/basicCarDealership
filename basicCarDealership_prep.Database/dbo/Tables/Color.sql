CREATE TABLE [dbo].[Color] (
    [ColorID]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ColorID] ASC),
    UNIQUE NONCLUSTERED ([ColorName] ASC)
);

