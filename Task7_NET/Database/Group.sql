CREATE TABLE [dbo].[Group]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [GroupName] NVARCHAR(20) NOT NULL,
	[SpecialtyId] INT NOT NULL DEFAULT 1
	CONSTRAINT [FK_Group_Specialty] FOREIGN KEY([SpecialtyId]) REFERENCES [Specialty]([Id])
)
