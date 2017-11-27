
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2015 12:13:34
-- Generated from EDMX file: D:\Dropbox\DailySoft\Projet\School\School.Model\SchoolModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [School];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Wording] nvarchar(max)  NOT NULL,
    [NumberOfDays] int  NOT NULL
);
GO

-- Creating table 'Trainee'
CREATE TABLE [dbo].[Trainee] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CourseTrainee'
CREATE TABLE [dbo].[CourseTrainee] (
    [Course_ID] int  NOT NULL,
    [Trainee_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Trainee'
ALTER TABLE [dbo].[Trainee]
ADD CONSTRAINT [PK_Trainee]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Course_ID], [Trainee_ID] in table 'CourseTrainee'
ALTER TABLE [dbo].[CourseTrainee]
ADD CONSTRAINT [PK_CourseTrainee]
    PRIMARY KEY NONCLUSTERED ([Course_ID], [Trainee_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Course_ID] in table 'CourseTrainee'
ALTER TABLE [dbo].[CourseTrainee]
ADD CONSTRAINT [FK_CourseTrainee_Course]
    FOREIGN KEY ([Course_ID])
    REFERENCES [dbo].[Course]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Trainee_ID] in table 'CourseTrainee'
ALTER TABLE [dbo].[CourseTrainee]
ADD CONSTRAINT [FK_CourseTrainee_Trainee]
    FOREIGN KEY ([Trainee_ID])
    REFERENCES [dbo].[Trainee]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTrainee_Trainee'
CREATE INDEX [IX_FK_CourseTrainee_Trainee]
ON [dbo].[CourseTrainee]
    ([Trainee_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------