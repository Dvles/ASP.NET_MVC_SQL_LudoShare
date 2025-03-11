CREATE TABLE [dbo].[Associer_Jeux_Tag]
(
    [Jeux_Id] UNIQUEIDENTIFIER NOT NULL,
    [Tag_Id] INT NOT NULL,
    PRIMARY KEY ([Jeux_Id], [Tag_Id]),
    FOREIGN KEY ([Jeux_Id]) REFERENCES [Jeux]([Jeux_Id]) ON DELETE CASCADE,
    FOREIGN KEY ([Tag_Id]) REFERENCES [Tag]([Tag_Id]) ON DELETE CASCADE
);
