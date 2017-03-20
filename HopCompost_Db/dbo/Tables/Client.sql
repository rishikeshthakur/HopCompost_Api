CREATE TABLE [dbo].[Client]
(
	[Id] INT identity (1,1), 
    [Name] NVARCHAR(100) NOT NULL, 
    [Address] NVARCHAR(MAX) NULL, 
    [EmergencyContact] NVARCHAR(50) NULL,
	Constraint PK_Client Primary Key Clustered (id)
)
