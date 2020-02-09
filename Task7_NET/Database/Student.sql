CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [Surname] NVARCHAR(20) NOT NULL, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Patronymic] NVARCHAR(20) NOT NULL, 
    [Gender] NVARCHAR(20) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [GroupId] INT NOT NULL, 
    CONSTRAINT [FK_Student_Group] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id])
)
