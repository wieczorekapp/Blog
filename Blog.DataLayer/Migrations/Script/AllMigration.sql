IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Url] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [Tags] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Url] nvarchar(max) NULL,
        CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Login] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [ContactInfo] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_ContactInfo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ContactInfo_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [ShortDescription] nvarchar(max) NULL,
        [Url] nvarchar(max) NULL,
        [Published] bit NOT NULL,
        [PostOn] datetime2 NOT NULL,
        [Modified] datetime2 NULL,
        [Type] int NOT NULL,
        [UserId] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE TABLE [PostTag] (
        [PostsId] int NOT NULL,
        [TagsId] int NOT NULL,
        CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostsId], [TagsId]),
        CONSTRAINT [FK_PostTag_Posts_PostsId] FOREIGN KEY ([PostsId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PostTag_Tags_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Url') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [Name], [Url])
    VALUES (1, N''All general posts'', N''General'', N''general'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Url') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_ContactInfo_UserId] ON [ContactInfo] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE INDEX [IX_Posts_CategoryId] ON [Posts] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE INDEX [IX_Posts_UserId] ON [Posts] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    CREATE INDEX [IX_PostTag_TagsId] ON [PostTag] ([TagsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220829205047_InitMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220829205047_InitMigration', N'5.0.17');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830193600_AddLongDescriptionToPost')
BEGIN
    ALTER TABLE [Posts] ADD [LongDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830193600_AddLongDescriptionToPost')
BEGIN
    UPDATE POSTS SET LongDescription = Description;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830193600_AddLongDescriptionToPost')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220830193600_AddLongDescriptionToPost', N'5.0.17');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830200158_AddImageUrlToPost')
BEGIN
    ALTER TABLE [Posts] ADD [ImageUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830200158_AddImageUrlToPost')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220830200158_AddImageUrlToPost', N'5.0.17');
END;
GO

COMMIT;
GO

