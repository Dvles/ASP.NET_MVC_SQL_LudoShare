CREATE TABLE [dbo].[Utilisateur]
(
    [Utilisateur_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
    [Email] NVARCHAR(320) NOT NULL,
    [MotDePasse] VARBINARY(64) NOT NULL,
    [Salt] UNIQUEIDENTIFIER NOT NULL,
    [Pseudo] NVARCHAR(64) NOT NULL,
    [DateCreation] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [DateDesactivation] DATETIME2 NULL, -- NULL si actif, sinon désactivé

    -- Colonne calculée pour indiquer si l'utilisateur est actif (1 = actif, 0 = désactivé)
    [IsActive] AS (CASE WHEN DateDesactivation IS NULL THEN 1 ELSE 0 END) PERSISTED,

    CONSTRAINT UQ_Pseudo UNIQUE ([Pseudo])
);
