CREATE PROCEDURE SP_Jeux_GetAll_Filtered
    @NomPattern NVARCHAR(64) = NULL,
    @Tag NVARCHAR(64) = NULL,
    @AgeMin TINYINT = NULL,
    @AgeMax TINYINT = NULL,
    @NbJoueurMin TINYINT = NULL,
    @NbJoueurMax TINYINT = NULL,
    @DureeMin SMALLINT = NULL,
    @DureeMax SMALLINT = NULL
AS
BEGIN
    SET NOCOUNT ON; -- better sql performance

    SELECT DISTINCT 
        j.Jeux_Id, j.Nom, j.Description, j.AgeMin, j.AgeMax, 
        j.NbJoueurMin, j.NbJoueurMax, j.DureeMinute, j.DateCreation
    FROM Jeux j
    LEFT JOIN Associer_Jeux_Tag jt ON j.Jeux_Id = jt.Jeux_Id
    LEFT JOIN Tags t ON jt.Tag_Id = t.Tag_Id
    WHERE 
        (@NomPattern IS NULL OR j.Nom LIKE '%' + @NomPattern + '%')
        AND (@Tag IS NULL OR t.Nom LIKE '%' + @Tag + '%')
        AND (@AgeMin IS NULL OR j.AgeMin >= @AgeMin)
        AND (@AgeMax IS NULL OR j.AgeMax <= @AgeMax)
        AND (@NbJoueurMin IS NULL OR j.NbJoueurMin >= @NbJoueurMin)
        AND (@NbJoueurMax IS NULL OR j.NbJoueurMax <= @NbJoueurMax)
        AND (@DureeMin IS NULL OR j.DureeMinute >= @DureeMin)
        AND (@DureeMax IS NULL OR j.DureeMinute <= @DureeMax)
    ORDER BY j.Nom;
END;
