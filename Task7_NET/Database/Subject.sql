CREATE TABLE [dbo].[Subject]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [SybjectName] NVARCHAR(50) NOT NULL, 
    [SubjectType] NVARCHAR(20) NOT NULL
)
