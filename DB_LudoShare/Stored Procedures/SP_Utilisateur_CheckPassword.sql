CREATE PROCEDURE [dbo].[SP_Utilisateur_CheckPassword]
	@pseudo NVARCHAR(320),
	@motDePasse NVARCHAR(64)
AS
BEGIN
	SELECT [Utilisateur_Id]
		FROM [Utilisateur]
		WHERE	[Pseudo] = @pseudo
			AND [MotDePasse] = [dbo].[SF_SaltAndHash](@motDePasse,[Salt])
END