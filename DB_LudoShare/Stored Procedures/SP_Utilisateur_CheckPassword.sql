CREATE PROCEDURE [dbo].[SP_Utilisateur_CheckPassword]
	@pseudo NVARCHAR(320),
	@motDePasse NVARCHAR(32)
AS
BEGIN
	SELECT [User_Id]
		FROM [User]
		WHERE	[Pseudo] = @pseudo
			AND [MotDePasse] = [dbo].[SF_SaltAndHash](@motDePasse,[Salt])
END