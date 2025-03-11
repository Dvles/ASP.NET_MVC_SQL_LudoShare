CREATE PROCEDURE SP_Associer_Jeux_Tag
    @Jeux_Id UNIQUEIDENTIFIER,
    @Tag_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Vérification de l'existence des enregistrements
    IF NOT EXISTS (SELECT 1 FROM Tag WHERE Tag_Id = @Tag_Id)
    BEGIN
        RAISERROR('Le tag spécifié n''existe pas.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Jeux WHERE Jeux_Id = @Jeux_Id)
    BEGIN
        RAISERROR('Le jeu spécifié n''existe pas.', 16, 1);
        RETURN;
    END

    -- Vérification si l'association existe déjà
    IF NOT EXISTS (SELECT 1 FROM Associer_Jeux_Tag WHERE Jeux_Id = @Jeux_Id AND Tag_Id = @Tag_Id)
    BEGIN
        INSERT INTO Associer_Jeux_Tag (Jeux_Id, Tag_Id)
        VALUES (@Jeux_Id, @Tag_Id);
    END
    ELSE
    BEGIN
        RAISERROR('Cette association existe déjà.', 16, 1);
    END
END;
