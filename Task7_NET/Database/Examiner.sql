﻿CREATE TABLE [dbo].[Examiner]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY,
	[Surname] NVARCHAR(20) NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	[Patronymic] NVARCHAR(20) NOT NULL
)
