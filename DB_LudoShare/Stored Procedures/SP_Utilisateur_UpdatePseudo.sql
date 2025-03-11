CREATE PROCEDURE UpdatePseudo
    @UtilisateurId UNIQUEIDENTIFIER,
    @NouveauPseudo NVARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Utilisateur WHERE Pseudo = @NouveauPseudo)
    BEGIN
        RAISERROR('Ce pseudo est déjà utilisé', 16, 1);
        RETURN;
    END

    UPDATE Utilisateur
    SET Pseudo = @NouveauPseudo
    WHERE Utilisateur_Id = @UtilisateurId;
END;
