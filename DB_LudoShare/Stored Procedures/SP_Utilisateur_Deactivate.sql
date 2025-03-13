CREATE PROCEDURE SP_Utilisateur_GetById
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Utilisateur_Id, Pseudo, MotDePasse, Salt, DateCreation, DateDesactivation
    FROM Utilisateur
    WHERE Utilisateur_Id = @UtilisateurId
    AND DateDesactivation IS NULL; -- Exclure les utilisateurs désactivés
END;
