CREATE TABLE [dbo].[Contract]
(
	[Id] INT identity (1,1), 
    [ClientId] INT NOT NULL, 
    [GreenBinCount] INT NULL, 
    [GreyBinCount] INT NULL, 
    [BlueBinCount] INT NULL,
	Constraint PK_Contract Primary Key Clustered (id),
	CONSTRAINT FK_Contract_Client FOREIGN KEY (ClientId) references dbo.Client (id)
)
