CREATE TABLE [dbo].[Jeux]
(
	[Jeux_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	[Nom] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(512) NOT NULL,
	[AgeMin] TINYINT CHECK (AgeMin >= 0),
	[AgeMax] TINYINT CHECK (AgeMax >= AgeMin),
	[NbJoueurMin] TINYINT CHECK (NbJoueurMin >= 0),
	[NbJoueurMax] TINYINT CHECK (NbJoueurMax >= NbJoueurMin),
	[DureeMinute] SMALLINT CHECK (DureeMinute > 0),
	[DateCreation] DATETIME2 NOT NULL DEFAULT GETDATE(),

)
