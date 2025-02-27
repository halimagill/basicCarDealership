CREATE TABLE [dbo].[Make] (
    [MakeID]   INT           IDENTITY (1, 1) NOT NULL,
    [MakeName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([MakeID] ASC),
    UNIQUE NONCLUSTERED ([MakeName] ASC)
);

