CREATE PROCEDURE GetById
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Utilisateur_Id, Email, Pseudo, DateCreation, DateDesactivation
    FROM Utilisateur
    WHERE Utilisateur_Id = @UtilisateurId;
END;
