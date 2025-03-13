CREATE TABLE [dbo].[Jeux]
(
	[Jeux_Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	[Nom] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(512) NOT NULL,
	[AgeMin] INT CHECK (AgeMin >= 0),
	[AgeMax] INT CHECK (AgeMax >= AgeMin),
	[NbJoueurMin] INT CHECK (NbJoueurMin >= 0),
	[NbJoueurMax] INT CHECK (NbJoueurMax >= NbJoueurMin),
	[DureeMinute] INT CHECK (DureeMinute > 0),
	[DateCreation] DATETIME2 NOT NULL DEFAULT GETDATE(),
	CONSTRAINT CK_AgeMax CHECK (AgeMax >= AgeMin) 
)
