
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2013 14:07:11
-- Generated from EDMX file: H:\Development\BookingSite\MvcApplication4\Models\Model1.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activity'
CREATE TABLE [dbo].[Activity] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [MaxPerson] int  NULL,
    [Duration] int  NOT NULL,
    [CompanyId] int  NOT NULL
);
GO

-- Creating table 'Booking'
CREATE TABLE [dbo].[Booking] (
    [Id] int  NOT NULL,
    [ActivityId] int  NULL,
    [PersonId] int  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Company_Id] int  NULL
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

-- Creating foreign key on [Company_Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [FK_CompanyPerson]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyPerson'
CREATE INDEX [IX_FK_CompanyPerson]
ON [dbo].[Person]
    ([Company_Id]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------