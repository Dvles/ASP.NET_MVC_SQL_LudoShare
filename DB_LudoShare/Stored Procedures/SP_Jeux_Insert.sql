CREATE PROCEDURE SP_Jeux_Insert
    @Nom NVARCHAR(64),
    @Description NVARCHAR(512),
    @AgeMin INT,
    @AgeMax INT,
    @NbJoueurMin INT,
    @NbJoueurMax INT,
    @DureeMinute INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewId UNIQUEIDENTIFIER = NEWID();

    INSERT INTO Jeux (Jeux_Id, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation)
    OUTPUT inserted.Jeux_Id
    VALUES (@NewId, @Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute, GETDATE());
END;
