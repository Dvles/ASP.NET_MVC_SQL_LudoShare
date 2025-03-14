CREATE PROCEDURE [dbo].[SP_Utilisateur_CheckPassword]
    @email NVARCHAR(320),
    @motDePasse NVARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Utilisateur_Id
    FROM Utilisateur
    WHERE Email = @email
        AND MotDePasse = [dbo].[SF_SaltAndHash](@motDePasse, Salt)
        AND DateDesactivation IS NULL; -- Seuls les comptes actifs peuvent se connecter
END