CREATE PROCEDURE SP_Utilisateur_Insert
    @Pseudo NVARCHAR(64),
    @MotDePasse NVARCHAR(32)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Utilisateur_Id UNIQUEIDENTIFIER = NEWID();
    DECLARE @Salt UNIQUEIDENTIFIER = NEWID();

    INSERT INTO Utilisateur (Utilisateur_Id, Pseudo, MotDePasse, Salt, DateCreation)
    VALUES (@Utilisateur_Id, @Pseudo, dbo.SF_SaltAndHash(@MotDePasse, @Salt), @Salt, GETDATE());

    SELECT @Utilisateur_Id;
END
