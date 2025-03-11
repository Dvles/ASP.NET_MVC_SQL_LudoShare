CREATE PROCEDURE Deactivate
    @UtilisateurId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Utilisateur
    SET DateDesactivation = GETDATE()
    WHERE Utilisateur_Id = @UtilisateurId;
END;

