CREATE PROCEDURE [dbo].[SP_Utilisateur_CheckPassword]
	@email NVARCHAR(320),
	@motDePasse NVARCHAR(64)
AS
BEGIN
	SELECT [Utilisateur_Id]
		FROM [Utilisateur]
		WHERE	[Email] = @email
			AND [MotDePasse] = [dbo].[SF_SaltAndHash](@motDePasse,[Salt])
END