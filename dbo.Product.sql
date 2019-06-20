CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [AddingDate] DATETIME NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Category] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Color] NVARCHAR(MAX) NOT NULL, 
    [Size] NVARCHAR(MAX) NOT NULL, 
    [Count] INT NOT NULL

)
