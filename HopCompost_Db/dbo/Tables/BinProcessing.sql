CREATE TABLE [dbo].[BinProcessing] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [ClientId]          INT NOT NULL,
    [BinNumber]         INT NULL,
    [MeatPercentage]    INT NULL,
    [ProducePercentage] INT NULL,
    [BulkPercentage]    INT NULL,
    CONSTRAINT [PK_BinProcessing] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BinProcessing_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

