-- SQL 

USE [School];

-- Alimentation de la table des stagiaires. 
INSERT INTO Trainee(Name, FirstName) VALUES ('DEROUX', 'Alain')
INSERT INTO Trainee(Name, FirstName) VALUES ('RAVAILLE', 'James')
INSERT INTO Trainee(Name, FirstName) VALUES ('SIRON', 'Karl')
INSERT INTO Trainee(Name, FirstName) VALUES ('EMATO', 'Julie') 

-- Alimentation de la table des stagiaires. 
INSERT INTO Course(Wording, NumberOfDays) VALUES ('SQL Server - Administration de serveurs', 5)
INSERT INTO Course(Wording, NumberOfDays) VALUES ('XHTML / CSS', 3)
INSERT INTO Course(Wording, NumberOfDays) VALUES ('C#', 5)
INSERT INTO Course(Wording, NumberOfDays) VALUES ('ASP .NET 3.5', 5)
INSERT INTO Course(Wording, NumberOfDays) VALUES ('ASP .NET AJAX', 3) 

-- Affectation des cours aux stagiaires.
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (1, 1)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (1, 3)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (2, 2)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (2, 1)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (2, 3)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (2, 4)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (3, 1)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (3, 4)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (3, 5)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (4, 4)
INSERT INTO CourseTrainee(Trainee_ID, Course_ID) VALUES (4, 5)