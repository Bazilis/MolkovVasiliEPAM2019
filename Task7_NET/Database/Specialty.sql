CREATE TABLE [dbo].[Specialty]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY,
	[SpecialtyCode] NVARCHAR(20) NOT NULL,
	[SpecialtyName] NVARCHAR(50) NOT NULL,
	[SpecialtyDescribe] NVARCHAR(MAX) NULL
)
