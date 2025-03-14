--DECLARE @NewUserId UNIQUEIDENTIFIER;

--EXEC SP_Utilisateur_Insert 
--    @Pseudo = 'Leslie',
--    @MotDePasse = 'aaaaa',
--    @Utilisateur_Id = @NewUserId OUTPUT; -- Capture the output

--SELECT @NewUserId AS 'New User ID';
EXEC SP_Utilisateur_Insert 
    @Email = 'test@example.com', 
    @Pseudo = 'TestUser', 
    @MotDePasse = 'MonMotDePasse123'

