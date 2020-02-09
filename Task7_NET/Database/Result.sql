CREATE TABLE [dbo].[Result]
(
	[Id] INT IDENTITY (1,1) PRIMARY KEY, 
    [ExamId] INT NOT NULL, 
    [StudentId] INT NOT NULL, 
    [StudentsGrade] FLOAT NOT NULL,
	CONSTRAINT [CK_Result_StudentGrade] CHECK([StudentsGrade] >= 0.0 AND [StudentsGrade] <= 100.0),
    CONSTRAINT [FK_Result_Exam] FOREIGN KEY ([ExamId]) REFERENCES [Exam]([Id]), 
    CONSTRAINT [FK_Result_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id])
)
