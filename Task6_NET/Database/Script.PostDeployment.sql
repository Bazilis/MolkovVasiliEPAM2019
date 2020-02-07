/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO [Group] AS Target
   USING  (VALUES ('IT31'),
				  ('IT32'),
				  ('IT33'))
AS Source (GroupName)
ON Target.GroupName = Source.GroupName
WHEN NOT MATCHED BY TARGET THEN
INSERT (GroupName)
VALUES (GroupName);


MERGE INTO [Subject] AS Target
   USING  (VALUES ('Math', 'Exam'),
				  ('History', 'Credit'),
				  ('Physics', 'Credit'))
AS Source (SybjectName, SubjectType)
ON (Target.SybjectName = Source.SybjectName AND
	Target.SubjectType = Source.SubjectType)
WHEN NOT MATCHED BY TARGET THEN
INSERT (SybjectName, SubjectType)
VALUES (SybjectName, SubjectType);


MERGE INTO [Exam] AS Target
   USING  (VALUES ( 1, '2003-01-01', 1, 1),
				  ( 2, '2004-01-01', 2, 1),
				  ( 3, '2005-01-02', 3, 2))
AS Source (SessionNumber, ExamDate, GroupId, SubjectId)
ON (Target.SessionNumber = Source.SessionNumber AND
	Target.ExamDate = Source.ExamDate AND
	Target.GroupId = Source.GroupId AND
	Target.SubjectId = Source.SubjectId)
WHEN NOT MATCHED BY TARGET THEN
INSERT (SessionNumber, ExamDate, GroupId, SubjectId)
VALUES (SessionNumber, ExamDate, GroupId, SubjectId);


MERGE INTO [Student] AS Target
 USING (VALUES ('Shikhina', 'Diana', 'Rostislavovna', 'Female', '2000-01-01', 1),
			   ('Ambrazhevicha', 'Agafya', 'Petrovna', 'Female', '2000-01-02', 2),
		       ('Avdeev', 'Mstislav', 'Sevastyanovich', 'Male', '2000-01-03', 3),
		       ('Mukoseeva', 'Aza', 'Nestorovna', 'Female', '2000-01-04', 2),
		       ('Kulibin', 'Artem', 'Mechislavovich', 'Male', '2000-01-05', 1),
		       ('Kutyakova', 'Zoya', 'Vladlenovna', 'Female', '2000-01-06', 3),
		       ('Krasnova', '﻿Agaata', 'Efimovna', 'Female', '2000-01-07', 1),
		       ('Livshits', 'Valeriy', 'Erofeevich', 'Male', '2000-01-08', 2),
		       ('Nyrkova', 'Irina', 'Kuzmevna', 'Female', '2000-01-09', 3),
		       ('Kireev', 'Lavr', 'Karlovich', 'Male', '2000-02-01', 2),
		       ('Chaadaeva', 'Roza', 'Olegovna', 'Female', '2000-02-02', 1),
		       ('Suruzhu', 'Rimma', 'Georgievna', 'Female', '2000-02-03', 3),
		       ('Dvoryankin', 'Adam', 'Miroslavovich', 'Male', '2000-02-04', 1),
		       ('Ozhegova', 'Nika', 'Ivanovna', 'Female', '2000-02-05', 2),
		       ('Trofimova', 'Zlata', 'Karpovna', 'Female', '2000-02-06', 3),
		       ('Gagolin', 'Artem', 'Platonovich', 'Male', '2000-02-07', 2),
		       ('Boyarinova', 'Zinaida', 'Filippovna', 'Female', '2000-02-08', 1),
		       ('Pustova', 'Natalya', 'Nikolaevna', 'Female', '2000-02-09', 3),
		       ('Kruchinkin', 'Demyan', 'Sokratovich', 'Male', '2000-03-01', 1),
		       ('Eventova', 'Vasilisa', 'Afanasievna', 'Female', '2000-03-02', 2),
		       ('Shurshalina', 'Irina', 'Ilyevna', 'Female', '2000-03-03', 3),
		       ('Shashlova', 'Antonina', 'Ilyevna', 'Female', '2000-03-04', 2),
		       ('Sarychev', 'Bronislav', 'Ernstovich', 'Male', '2000-03-05', 1),
		       ('Bysov', 'Lukyan', 'Modestovich', 'Male', '2000-03-06', 3),
		       ('Velyaminova', 'Eleonora', 'Nikolaevna', 'Female', '2000-03-07', 1),
		       ('Pankratov', 'Andriyan', 'Arkhipovich', 'Male', '2000-03-08', 2),
		       ('Karzhaubaev', 'Aleksey', 'Glebovich', 'Male', '2000-03-09', 3),
		       ('Laer', 'Izmail', 'Valerievich', 'Male', '2000-04-01', 2),
		       ('Shchitta', 'Elvira', 'Andriyanovna', 'Female', '2000-04-02', 1),
		       ('Yavchunovskiy', 'Demyan', 'Gerasimovich', 'Male', '2000-04-03', 3))

AS Source (Surname, [Name], Patronymic, Gender, DateOfBirth, GroupId)
ON (Target.Surname = Source.Surname AND
	Target.[Name] = Source.[Name] AND
	Target.Patronymic = Source.Patronymic AND
	Target.Gender = Source.Gender AND
	Target.DateOfBirth = Source.DateOfBirth AND
	Target.GroupId = Source.GroupId)
WHEN NOT MATCHED BY TARGET THEN
INSERT (Surname, [Name], Patronymic, Gender, DateOfBirth, GroupId)
VALUES (Surname, [Name], Patronymic, Gender, DateOfBirth, GroupId);


MERGE INTO [Result] AS Target
   USING  (VALUES (2, 5, 90),
				  (3, 8, 80),
				  (1, 3, 50))
AS Source (ExamId, StudentId, StudentGrade)
ON (Target.ExamId = Source.ExamId AND
	Target.StudentId = Source.StudentId)
WHEN NOT MATCHED BY TARGET THEN
INSERT (ExamId, StudentId, StudentGrade)
VALUES (ExamId, StudentId, StudentGrade);
