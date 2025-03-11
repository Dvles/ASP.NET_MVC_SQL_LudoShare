﻿CREATE TABLE [dbo].[Emprunt]
(
	[Emprunt_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	[Jeux_Id] UNIQUEIDENTIFIER NOT NULL, 
	[DateEmprunt] DATETIME2 NOT NULL,
	[DateRetour] DATETIME2 NOT NULL,
	[EvaluationPreteur] TINYINT,
	[EvaluationEmprunteur] TINYINT,
	CONSTRAINT FK_Emprunt_Jeu FOREIGN KEY ([Jeux_Id]) REFERENCES [dbo].[Jeux]([Jeux_Id]) ON DELETE CASCADE,


)

