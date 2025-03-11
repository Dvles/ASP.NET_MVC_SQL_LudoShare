CREATE PROCEDURE SP_Tags_LinkToJeu
    @Jeux_Id UNIQUEIDENTIFIER,
    @Tag_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Jeux_Tags (Jeux_Id, Tag_Id)
    VALUES (@Jeux_Id, @Tag_Id);
END;
