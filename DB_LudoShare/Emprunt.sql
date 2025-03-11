CREATE TABLE [dbo].[Emprunt]
(
    [Emprunt_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    [JeuxPossédés_Id] UNIQUEIDENTIFIER NOT NULL,
    [Preteur_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Emprunteur_Id] UNIQUEIDENTIFIER NOT NULL,
    [DateEmprunt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [DateRetour] DATETIME2 NULL,
    [EvaluationPreteur] INT CHECK (EvaluationPreteur BETWEEN 0 AND 5),
    [EvaluationEmprunteur] INT CHECK (EvaluationEmprunteur BETWEEN 0 AND 5),

    CONSTRAINT FK_Emprunt_UPJ FOREIGN KEY ([JeuxPossédés_Id]) 
        REFERENCES [dbo].[JeuxPossédés]([JeuxPossédés_Id]) 
        ON DELETE CASCADE,

    CONSTRAINT FK_Emprunt_Prete FOREIGN KEY ([Preteur_Id]) 
        REFERENCES [dbo].[Utilisateur]([Utilisateur_Id]) 
        ON DELETE NO ACTION,

    CONSTRAINT FK_Emprunt_Emprunte FOREIGN KEY ([Emprunteur_Id]) 
        REFERENCES [dbo].[Utilisateur]([Utilisateur_Id]) 
        ON DELETE NO ACTION
);
