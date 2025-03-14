CREATE PROCEDURE SP_Utilisateur_GetByEmail
    @Email NVARCHAR(320)
AS
BEGIN
    SET NOCOUNT ON;

    -- Sélectionner les informations de l'utilisateur correspondant à l'email fourni
    SELECT Utilisateur_Id, Email, Pseudo, MotDePasse, Salt, DateCreation, DateDesactivation
    FROM Utilisateur
    WHERE Email = @Email;
END
