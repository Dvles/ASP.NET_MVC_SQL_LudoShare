CREATE PROCEDURE SP_Utilisateur_Insert
    @Pseudo NVARCHAR(64),
    @MotDePasse NVARCHAR(64) 
AS
BEGIN
    DECLARE @Utilisateur_Id UNIQUEIDENTIFIER = NEWID();
    DECLARE @Salt UNIQUEIDENTIFIER = NEWID(); -- Generate a unique salt
    DECLARE @HashedPassword VARBINARY(64);

    SET @HashedPassword = HASHBYTES('SHA2_256', @MotDePasse + CAST(@Salt AS NVARCHAR(36)));

    INSERT INTO Utilisateur (Utilisateur_Id, Pseudo, MotDePasse, Salt, DateCreation)
    VALUES (@Utilisateur_Id, @Pseudo, @HashedPassword, @Salt, GETDATE());

    SELECT @Utilisateur_Id AS Utilisateur_Id;
END
