IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Categoria] nvarchar(max),
    [Nome] nvarchar(max),
    [Preco] nvarchar(max),
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171105034235_Inicial', N'1.1.3');

GO

EXEC sp_rename N'Produtos.Preco', N'Unidade', N'COLUMN';

GO

ALTER TABLE [Produtos] ADD [PrecoUnitario] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171105034521_Unidade', N'1.1.3');

GO

