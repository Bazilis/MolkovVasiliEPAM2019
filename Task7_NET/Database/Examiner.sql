CREATE TABLE [dbo].[Examiner]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY,
	[ExaminerSurname] NVARCHAR(20) NOT NULL,
	[ExaminerName] NVARCHAR(20) NOT NULL,
	[ExaminerPatronymic] NVARCHAR(20) NOT NULL
)
