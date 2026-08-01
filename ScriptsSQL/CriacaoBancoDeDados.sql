CREATE DATABASE [AeC_Enderecos];
GO

USE [AeC_Enderecos];
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Usuario] nvarchar(100) NOT NULL,
    [Senha] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Enderecos] (
    [Id] int NOT NULL IDENTITY,
    [CEP] nvarchar(9) NOT NULL,
    [Logradouro] nvarchar(200) NOT NULL,
    [Complemento] nvarchar(200) NULL,
    [Bairro] nvarchar(120) NOT NULL,
    [Cidade] nvarchar(120) NOT NULL,
    [UF] nvarchar(2) NOT NULL,
    [Numero] nvarchar(20) NOT NULL,
    [UsuarioId] int NOT NULL,
    [CriadoPor] nvarchar(100) NOT NULL,
    [AtualizadoPor] nvarchar(100) NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Enderecos_CEP] ON [Enderecos] ([CEP]);
GO
CREATE INDEX [IX_Enderecos_Cidade] ON [Enderecos] ([Cidade]);
GO
CREATE INDEX [IX_Enderecos_UsuarioId] ON [Enderecos] ([UsuarioId]);
GO
CREATE UNIQUE INDEX [IX_Usuarios_Usuario] ON [Usuarios] ([Usuario]);
GO
