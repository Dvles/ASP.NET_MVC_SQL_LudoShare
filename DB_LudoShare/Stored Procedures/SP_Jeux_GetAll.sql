CREATE PROCEDURE [dbo].[SP_Jeux_GetAll]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [Jeux_Id],
        [Nom],
        [Description],
        [AgeMin],
        [AgeMax],
        [NbJoueurMin],
        [NbJoueurMax],
        [DureeMinute],
        [DateCreation]
    FROM [Jeux]
    ORDER BY [Nom];
END;

