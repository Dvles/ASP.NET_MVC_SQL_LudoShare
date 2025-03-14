﻿CREATE TABLE [dbo].[Utilisateur]
(
	[Utilisateur_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    [Email]      NVARCHAR (320)   NOT NULL,
    [MotDePasse] VARBINARY (64)   NOT NULL,
    [Salt] UNIQUEIDENTIFIER NOT NULL,
    [Pseudo] NVARCHAR  (64)  NOT NULL,
    [DateCreation] DATETIME2  NOT NULL DEFAULT GETDATE(),
    [DateDesactivation] DATETIME2, 
    CONSTRAINT UQ_Pseudo UNIQUE ([Pseudo])
)
