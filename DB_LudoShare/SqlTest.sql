DECLARE @NewUserId UNIQUEIDENTIFIER;

EXEC SP_Utilisateur_Insert 
    @Pseudo = 'TestUser',
    @MotDePasse = 'motdepasse123',
    @Utilisateur_Id = @NewUserId OUTPUT;  

SELECT @NewUserId AS Utilisateur_Id;
