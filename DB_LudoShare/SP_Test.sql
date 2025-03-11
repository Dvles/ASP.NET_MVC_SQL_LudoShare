--------🔹 Test Utilisateurs
--EXEC SP_Utilisateur_Insert @Pseudo = 'User1', @MotDePasse = '000000';
--EXEC SP_Utilisateur_Insert @Pseudo = 'User2', @MotDePasse = '000000';
--EXEC SP_Utilisateur_Insert @Pseudo = 'User3', @MotDePasse = '000000';
--EXEC SP_Utilisateur_Insert @Pseudo = 'User4', @MotDePasse = '000000';
--EXEC SP_Utilisateur_Insert @Pseudo = 'User5', @MotDePasse = '000000';

-------- 🔹 Test Jeux
--EXEC SP_Jeux_Insert 
--    @Nom = 'Catan',
--    @Description = 'Un jeu de stratégie où les joueurs échangent et construisent',
--    @AgeMin = 10,
--    @AgeMax = 99,
--    @NbJoueurMin = 3,
--    @NbJoueurMax = 4,
--    @DureeMinute = 90;

--EXEC SP_Jeux_Insert 
--    @Nom = 'Risk',
--    @Description = 'Un jeu de conquête stratégique où vous devez dominer le monde.',
--    @AgeMin = 10,
--    @AgeMax = 99,
--    @NbJoueurMin = 2,
--    @NbJoueurMax = 6,
--    @DureeMinute = 120;

--EXEC SP_Jeux_Insert 
--    @Nom = 'Dixit',
--    @Description = 'Un jeu de cartes basé des illustrations oniriques.',
--    @AgeMin = 8,
--    @AgeMax = 99,
--    @NbJoueurMin = 3,
--    @NbJoueurMax = 6,
--    @DureeMinute = 30;

--EXEC SP_Jeux_Insert 
--    @Nom = '7 Wonders',
--    @Description = 'Un jeu de développement de civilisation où vous devez bâtir une merveille du monde antique.',
--    @AgeMin = 10,
--    @AgeMax = 99,
--    @NbJoueurMin = 2,
--    @NbJoueurMax = 7,
--    @DureeMinute = 30;

--EXEC SP_Jeux_Insert 
--    @Nom = 'Pandemic',
--    @Description = 'Un jeu coopératif où les joueurs doivent enrayer une pandémie mondiale.',
--    @AgeMin = 8,
--    @AgeMax = 99,
--    @NbJoueurMin = 2,
--    @NbJoueurMax = 4,
--    @DureeMinute = 45;

-- EXEC SP_Jeux_GetById @Jeux_Id = 'bec95a87-a051-4489-949b-109c4be46a79';



--------🔹 Test TAG
--EXEC SP_Tags_Insert 'Dés';
--EXEC SP_Tags_Insert 'Stratégie';
--EXEC SP_Tags_Insert 'Cartes';
--EXEC SP_Tags_Insert 'Disney';
--EXEC SP_Tags_Insert 'Coopératif';
--EXEC SP_Tags_Insert 'Aventure';



EXEC dbo.SP_Jeux_AjouterTag '9bde17e4-9caa-465e-b0b5-16847344cdab9', 1;
EXEC dbo.SP_Jeux_AjouterTag '9bde17e4-9caa-465e-b0b5-16847344cdab', 2;
