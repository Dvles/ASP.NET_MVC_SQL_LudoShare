CREATE TABLE [dbo].[Emprunt]
(
    [Emprunt_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    [Jeux_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Preteur_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Emprunteur_Id] UNIQUEIDENTIFIER NOT NULL,
    [DateEmprunt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [DateRetour] DATETIME2 NULL, 
    [EvaluationPreteur] TINYINT CHECK (EvaluationPreteur BETWEEN 0 AND 5),
    [EvaluationEmprunteur] TINYINT CHECK (EvaluationEmprunteur BETWEEN 0 AND 5),

    CONSTRAINT FK_Emprunt_Jeu FOREIGN KEY ([Jeux_Id]) REFERENCES [dbo].[Jeux]([Jeux_Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Emprunt_Prete FOREIGN KEY ([Preteur_Id]) REFERENCES [dbo].[Utilisateur]([Utilisateur_Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Emprunt_Emprunte FOREIGN KEY ([Emprunteur_Id]) REFERENCES [dbo].[Utilisateur]([Utilisateur_Id]) ON DELETE CASCADE,


);


