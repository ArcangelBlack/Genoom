# Aplicación desarrollada en Asp.Net Core

Url: http://genoomapi.azurewebsites.net

### Estructura de Base de Datos:

CREATE TABLE [dbo].[Relationships] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [SourcePersonId] INT NULL,
    [TargetPersonId] INT NULL,
    [Relation]       INT NULL,
    CONSTRAINT [PK_Relationships] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Person] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [Lastname]  NVARCHAR (50) NULL,
    [Birthdate] DATETIME      NULL,
    [Deathdate] DATETIME      NULL,
    [Sex]       BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

### NOTA:
AL agregar nuevos Padres o Hijos se tiene que especificar el Sexo como tal. para poder ayudar a catalogar la relación exacta entre la Persona.
