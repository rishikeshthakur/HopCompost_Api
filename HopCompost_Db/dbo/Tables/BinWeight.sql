CREATE TABLE [dbo].[BinWeight] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [BinCollectionId] INT NOT NULL,
    [BinWeight]       FLOAT NULL,
    CONSTRAINT [PK_BinWeight] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BinWeight_BinCollection] FOREIGN KEY ([BinCollectionId]) REFERENCES [dbo].[BinCollection] ([Id])
);

