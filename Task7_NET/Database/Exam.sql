CREATE TABLE [dbo].[Exam]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [SessionNumber] INT NOT NULL, 
    [ExamDate] DATE NOT NULL, 
    [GroupId] INT NOT NULL, 
    [SubjectId] INT NOT NULL,
	[ExaminerId] INT NOT NULL DEFAULT 1
    CONSTRAINT [FK_Exam_Group] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id]), 
    CONSTRAINT [FK_Exam_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [Subject]([Id]),
	CONSTRAINT [FK_Exam_Examiner] FOREIGN KEY([ExaminerId]) REFERENCES [Examiner]([Id])
)
