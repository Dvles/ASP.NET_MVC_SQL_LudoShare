DECLARE @NewUserId UNIQUEIDENTIFIER;

EXEC SP_Utilisateur_Insert 
    @Pseudo = 'Leslie',
    @MotDePasse = 'aaaaa',
    @Utilisateur_Id = @NewUserId OUTPUT; -- Capture the output

SELECT @NewUserId AS 'New User ID';
