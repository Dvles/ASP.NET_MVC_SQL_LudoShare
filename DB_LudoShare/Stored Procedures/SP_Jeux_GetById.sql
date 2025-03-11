CREATE PROCEDURE SP_Jeux_GetById
    @Jeux_Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Jeux_Id, Nom, Description, AgeMin, AgeMax, NbJoueurMin, NbJoueurMax, DureeMinute, DateCreation
    FROM Jeux
    WHERE Jeux_Id = @Jeux_Id;
END;
