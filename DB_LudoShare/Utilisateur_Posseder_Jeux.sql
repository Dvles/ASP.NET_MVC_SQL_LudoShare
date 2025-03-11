CREATE TABLE [dbo].[Utilisateur_Posseder_Jeux]
(
    [UPJ_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    [Jeux_Id] UNIQUEIDENTIFIER NOT NULL,
    [Utilisateur_Id] UNIQUEIDENTIFIER NOT NULL,
    [Etat] NVARCHAR(50) NOT NULL, 
    FOREIGN KEY ([Jeux_Id]) REFERENCES [Jeux]([Jeux_Id]) ON DELETE CASCADE,
    FOREIGN KEY ([Utilisateur_Id]) REFERENCES [Utilisateur]([Utilisateur_Id]) ON DELETE CASCADE,
    CONSTRAINT CK_Etat CHECK (Etat IN ('Neuf', 'Abimé', 'Incomplet')) 
);

