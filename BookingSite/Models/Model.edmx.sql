
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/26/2013 14:56:58
-- Generated from EDMX file: G:\Development\BookingSite\BookingSite\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookingSite];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Booking_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_CompanyActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_PersonBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_PersonCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_ActivityCity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity];
GO
IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activity'
CREATE TABLE [dbo].[Activity] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Date] datetime  NOT NULL,
    [MaxPerson] int  NOT NULL,
    [Duration] int  NOT NULL,
    [CompanyId] int  NOT NULL,
    [Time] nvarchar(max)  NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'Booking'
CREATE TABLE [dbo].[Booking] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityId] int  NULL,
    [PersonId] int  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AdministratorPersonId] int  NULL,
    [HasAdministrator] bit  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [PK_Activity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [PK_Booking]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityId] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK_Booking_Activity]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Booking_Activity'
CREATE INDEX [IX_FK_Booking_Activity]
ON [dbo].[Booking]
    ([ActivityId]);
GO

-- Creating foreign key on [CompanyId] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_CompanyActivity]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyActivity'
CREATE INDEX [IX_FK_CompanyActivity]
ON [dbo].[Activity]
    ([CompanyId]);
GO

-- Creating foreign key on [PersonId] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK_PersonBooking]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonBooking'
CREATE INDEX [IX_FK_PersonBooking]
ON [dbo].[Booking]
    ([PersonId]);
GO

-- Creating foreign key on [AdministratorPersonId] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK_PersonCompany]
    FOREIGN KEY ([AdministratorPersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCompany'
CREATE INDEX [IX_FK_PersonCompany]
ON [dbo].[Company]
    ([AdministratorPersonId]);
GO

-- Creating foreign key on [CityId] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_ActivityCity]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityCity'
CREATE INDEX [IX_FK_ActivityCity]
ON [dbo].[Activity]
    ([CityId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------