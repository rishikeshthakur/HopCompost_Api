﻿CREATE TABLE [dbo].[BinCollection] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [ClientId]       INT           NOT NULL,
    [EmployeeId]     INT           NOT NULL,
    [GreenBinCount]  INT           NULL,
    [GreyBinCount]   INT           NULL,
    [BlueBinCount]   INT           NULL,
    [CollectionDurationInMinutes] INT NOT NULL,
    [CollectionDate] DATE          NOT NULL,
    [Status]         NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_BinCollection] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BinCollection_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_BinCollection_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);

