
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2017 19:04:16
-- Generated from EDMX file: C:\Users\lenovo\Documents\Visual Studio 2017\Projects\ASPNetTest\ASPWithoutWAPI\MessageDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyMessageDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChatChat_Meta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chat_MetaSet] DROP CONSTRAINT [FK_ChatChat_Meta];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatChatMembers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatMembersSet] DROP CONSTRAINT [FK_ChatChatMembers];
GO
IF OBJECT_ID(N'[dbo].[FK_MesagesChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MesagesSet] DROP CONSTRAINT [FK_MesagesChat];
GO
IF OBJECT_ID(N'[dbo].[FK_MesagesUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MesagesSet] DROP CONSTRAINT [FK_MesagesUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatSet] DROP CONSTRAINT [FK_UserChat];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChatMembers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatMembersSet] DROP CONSTRAINT [FK_UserChatMembers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChatMembers1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChatMembersSet] DROP CONSTRAINT [FK_UserChatMembers1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUser_Meta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_MetaSet] DROP CONSTRAINT [FK_UserUser_Meta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Chat_MetaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chat_MetaSet];
GO
IF OBJECT_ID(N'[dbo].[ChatMembersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatMembersSet];
GO
IF OBJECT_ID(N'[dbo].[ChatSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChatSet];
GO
IF OBJECT_ID(N'[dbo].[MesagesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MesagesSet];
GO
IF OBJECT_ID(N'[dbo].[User_MetaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_MetaSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Pass] nvarchar(max)  NOT NULL,
    [Nick] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User_MetaSet'
CREATE TABLE [dbo].[User_MetaSet] (
    [UserMetaID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Key] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChatSet'
CREATE TABLE [dbo].[ChatSet] (
    [ChatID] int IDENTITY(1,1) NOT NULL,
    [AdminID] int  NOT NULL,
    [CreationTime] datetime  NOT NULL,
    [ChatName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChatMembersSet'
CREATE TABLE [dbo].[ChatMembersSet] (
    [ChatMembersID] int IDENTITY(1,1) NOT NULL,
    [ChatID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [InvitingUser] int  NOT NULL
);
GO

-- Creating table 'MesagesSet'
CREATE TABLE [dbo].[MesagesSet] (
    [MessageID] int IDENTITY(1,1) NOT NULL,
    [ChatID] int  NOT NULL,
    [AuthorID] int  NOT NULL,
    [MessageText] nvarchar(max)  NOT NULL,
    [CreationTime] datetime  NOT NULL
);
GO

-- Creating table 'Chat_MetaSet'
CREATE TABLE [dbo].[Chat_MetaSet] (
    [ChatMetaID] int IDENTITY(1,1) NOT NULL,
    [ChatID] int  NOT NULL,
    [Key] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserMetaID] in table 'User_MetaSet'
ALTER TABLE [dbo].[User_MetaSet]
ADD CONSTRAINT [PK_User_MetaSet]
    PRIMARY KEY CLUSTERED ([UserMetaID] ASC);
GO

-- Creating primary key on [ChatID] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [PK_ChatSet]
    PRIMARY KEY CLUSTERED ([ChatID] ASC);
GO

-- Creating primary key on [ChatMembersID] in table 'ChatMembersSet'
ALTER TABLE [dbo].[ChatMembersSet]
ADD CONSTRAINT [PK_ChatMembersSet]
    PRIMARY KEY CLUSTERED ([ChatMembersID] ASC);
GO

-- Creating primary key on [MessageID] in table 'MesagesSet'
ALTER TABLE [dbo].[MesagesSet]
ADD CONSTRAINT [PK_MesagesSet]
    PRIMARY KEY CLUSTERED ([MessageID] ASC);
GO

-- Creating primary key on [ChatMetaID] in table 'Chat_MetaSet'
ALTER TABLE [dbo].[Chat_MetaSet]
ADD CONSTRAINT [PK_Chat_MetaSet]
    PRIMARY KEY CLUSTERED ([ChatMetaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'User_MetaSet'
ALTER TABLE [dbo].[User_MetaSet]
ADD CONSTRAINT [FK_UserUser_Meta]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUser_Meta'
CREATE INDEX [IX_FK_UserUser_Meta]
ON [dbo].[User_MetaSet]
    ([UserID]);
GO

-- Creating foreign key on [AdminID] in table 'ChatSet'
ALTER TABLE [dbo].[ChatSet]
ADD CONSTRAINT [FK_UserChat]
    FOREIGN KEY ([AdminID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChat'
CREATE INDEX [IX_FK_UserChat]
ON [dbo].[ChatSet]
    ([AdminID]);
GO

-- Creating foreign key on [InvitingUser] in table 'ChatMembersSet'
ALTER TABLE [dbo].[ChatMembersSet]
ADD CONSTRAINT [FK_UsersInvitesInChats]
    FOREIGN KEY ([InvitingUser])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInvitesInChats'
CREATE INDEX [IX_FK_UsersInvitesInChats]
ON [dbo].[ChatMembersSet]
    ([InvitingUser]);
GO

-- Creating foreign key on [UserID] in table 'ChatMembersSet'
ALTER TABLE [dbo].[ChatMembersSet]
ADD CONSTRAINT [FK_UsersChats]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersChats'
CREATE INDEX [IX_FK_UsersChats]
ON [dbo].[ChatMembersSet]
    ([UserID]);
GO

-- Creating foreign key on [AuthorID] in table 'MesagesSet'
ALTER TABLE [dbo].[MesagesSet]
ADD CONSTRAINT [FK_MesagesUser]
    FOREIGN KEY ([AuthorID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesagesUser'
CREATE INDEX [IX_FK_MesagesUser]
ON [dbo].[MesagesSet]
    ([AuthorID]);
GO

-- Creating foreign key on [ChatID] in table 'ChatMembersSet'
ALTER TABLE [dbo].[ChatMembersSet]
ADD CONSTRAINT [FK_ChatChatMembers]
    FOREIGN KEY ([ChatID])
    REFERENCES [dbo].[ChatSet]
        ([ChatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatChatMembers'
CREATE INDEX [IX_FK_ChatChatMembers]
ON [dbo].[ChatMembersSet]
    ([ChatID]);
GO

-- Creating foreign key on [ChatID] in table 'MesagesSet'
ALTER TABLE [dbo].[MesagesSet]
ADD CONSTRAINT [FK_MesagesChat]
    FOREIGN KEY ([ChatID])
    REFERENCES [dbo].[ChatSet]
        ([ChatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesagesChat'
CREATE INDEX [IX_FK_MesagesChat]
ON [dbo].[MesagesSet]
    ([ChatID]);
GO

-- Creating foreign key on [ChatID] in table 'Chat_MetaSet'
ALTER TABLE [dbo].[Chat_MetaSet]
ADD CONSTRAINT [FK_ChatChat_Meta]
    FOREIGN KEY ([ChatID])
    REFERENCES [dbo].[ChatSet]
        ([ChatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatChat_Meta'
CREATE INDEX [IX_FK_ChatChat_Meta]
ON [dbo].[Chat_MetaSet]
    ([ChatID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------