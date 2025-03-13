using System;
using BLL.Services;
using b = BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using FakeRepository;
using D = DAL.Entities;
using System.Collections.Generic;
using DAL.Services;
using DAL.Entities;

namespace ConsoleTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			///// TEST UTILISATEUR ////

			// UtilisateurService utilisateurService = new UtilisateurService();
			/*			Console.WriteLine("=== Test de l'authentification ===");
						//string pseudo = "TestUser";
						//string motDePasse = "motdepasse123";

						//Guid userId = utilisateurService.CheckPassword(pseudo, motDePasse);

						//if (userId == Guid.Empty)
						//{
						//	Console.WriteLine("❌ Échec de l'authentification : pseudo ou mot de passe incorrect.");
						//}
						//else
						//{
						//	Console.WriteLine($"✅ Authentification réussie ! User ID : {userId}");
						//}*/

			/*			//DAL TEST INSERT
						Utilisateur nouvelUtilisateur = new Utilisateur
						{
							Pseudo = "Jessica",
							MotDePasse = "motdepasse123"
						};

						try
						{
							// Insertion dans la base et récupération de l'ID
							Guid userId = utilisateurService.Insert(nouvelUtilisateur);

							// Affichage du résultat
							Console.WriteLine($"Utilisateur inséré avec succès ! ID: {userId}");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Erreur lors de l'insertion : {ex.Message}");
						}*/

			/*			//DAL TEST UpdatePseudo

			Guid utilisateurId = new Guid("c536b225-9dd6-48b4-8c61-a63d3cd37870");
			string nouveauPseudo = "Boyaka";

			try
			{
				utilisateurService.UpdatePseudo(utilisateurId, nouveauPseudo);
				Console.WriteLine($"✅ Pseudo mis à jour pour:  {utilisateurId} !");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Erreur: {ex.Message}");
			}*/

			/*						// DAL TEST GetByID
									Guid utilisateurId = Guid.Parse("c0973b53-f248-4686-9fab-49e51fb55120");

									try
									{
										// Récupération de l'utilisateur par ID
										Utilisateur utilisateur = utilisateurService.GetById(utilisateurId);

										// Affichage des informations récupérées
										Console.WriteLine("Utilisateur trouvé !");
										Console.WriteLine($"ID : {utilisateur.Utilisateur_Id}");
										Console.WriteLine($"Pseudo : {utilisateur.Pseudo}");
										Console.WriteLine($"Date de création : {utilisateur.DateCreation}");
										Console.WriteLine($"Date de désactivation : {(utilisateur.DateDesactivation.HasValue ? utilisateur.DateDesactivation.Value.ToString() : "Actif")}");

									}
									catch (Exception ex)
									{
										Console.WriteLine($"Erreur : {ex.Message}");
									}*/

			/* // DAL TEST SoftDelete

						Guid utilisateurId = Guid.Parse("3622b822-c561-45d8-a20c-6a9141e5b8fa");

						try
						{
							// Désactiver l'utilisateur
							utilisateurService.Deactivate(utilisateurId);
							Console.WriteLine($"Utilisateur {utilisateurId} désactivé avec succès !");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Erreur : {ex.Message}");
						}*/

			/*			// Initialisation du FakeRepository
						IUtilisateurRepository<B.Utilisateur> fakeRepo = new FakeUtilisateurRepository();
						UtilisateurService utilisateurService = new UtilisateurService(fakeRepo);

						// Ajout manuel d'un utilisateur dans le FakeRepository
						Utilisateur existingUser = new Utilisateur
						{
							Utilisateur_Id = Guid.Parse("c536b225-9dd6-48b4-8c61-a63d3cd37870"),
							Pseudo = "Boyaka",
							MotDePasse = "motdepasse123",
							DateCreation = DateTime.Now
						};*/

			/*// BLL TEST Insert
			fakeRepo.Insert(existingUser);
			Console.WriteLine($"✅ Utilisateur inséré avec ID: {existingUser.Utilisateur_Id}");

			// BLL TEST CheckPassword
			Guid authenticatedUserId = utilisateurService.CheckPassword("Boyaka", "motdepasse123");

			if (authenticatedUserId != Guid.Empty)
			{
				Console.WriteLine($"✅ Utilisateur authentifié avec ID: {authenticatedUserId}");
			}
			else
			{
				Console.WriteLine("❌ Échec de l'authentification : Pseudo ou mot de passe incorrect.");
			}

			// BLL TEST GetById
			Utilisateur fetchedUser = utilisateurService.GetById(existingUser.Utilisateur_Id);
			if (fetchedUser != null)
			{
				Console.WriteLine($"✅ Utilisateur récupéré: {fetchedUser.Pseudo}");
			}
			else
			{
				Console.WriteLine("❌ Utilisateur non trouvé.");
			}

			// BLL Test UpdatePseudo
			utilisateurService.UpdatePseudo(existingUser.Utilisateur_Id, "UpdatedUser");
			Console.WriteLine($"✅ Pseudo mis à jour pour l'utilisateur {existingUser.Utilisateur_Id}");

			// BLL Test Deactive (soft delete)
			utilisateurService.Deactivate(existingUser.Utilisateur_Id);
			Console.WriteLine($"✅ Utilisateur {existingUser.Utilisateur_Id} désactivé.");*/
			/*			// MAPPER TESTS -- Création d'un utilisateur DAL (imitating DB)
			D.Utilisateur dalUser = new D.Utilisateur
			{
				Utilisateur_Id = Guid.NewGuid(),
				Pseudo = "sabrina",
				MotDePasse = "motdepasse123",
				DateCreation = DateTime.Now
			};

			// Conversion DAL -> BLL
			b.Utilisateur bllUser = dalUser.ToBLL();

			// Vérification des valeurs
			Console.WriteLine("=== Test ToBLL ===");
			Check("ID", dalUser.Utilisateur_Id, bllUser.Utilisateur_Id);
			Check("Pseudo", dalUser.Pseudo, bllUser.Pseudo);
			Check("Mot de passe", dalUser.MotDePasse, bllUser.MotDePasse);
			Check("Date de création", dalUser.DateCreation, bllUser.DateCreation);

			// Conversion BLL -> DAL
			D.Utilisateur convertedBackToDal = bllUser.ToDAL();


			Console.WriteLine("\n=== Test ToDAL ===");
			Check("ID", bllUser.Utilisateur_Id, convertedBackToDal.Utilisateur_Id);
			Check("Pseudo", bllUser.Pseudo, convertedBackToDal.Pseudo);
			Check("Mot de passe", bllUser.MotDePasse, convertedBackToDal.MotDePasse);
			Check("Date de création", bllUser.DateCreation, convertedBackToDal.DateCreation);
		}

		static void Check<T>(string label, T expected, T actual)
		{
			if (expected.Equals(actual))
			{
				Console.WriteLine($"✅ {label} : OK ({expected})");
			}
			else
			{
				Console.WriteLine($"❌ {label} : ERREUR - attendu {expected}, obtenu {actual}");
			}
		}*/
			///// TEST JEUX ////

			JeuxService jeuxService = new JeuxService();

			Console.WriteLine("===== Test GetAll() =====");
			foreach (Jeux jeu in jeuxService.GetAll())
			{
				Console.WriteLine($"{jeu.Jeux_Id} - {jeu.Nom} ({jeu.AgeMin}-{jeu.AgeMax} ans) {jeu.NbJoueurMin}-{jeu.NbJoueurMax} joueurs");
			}

			Console.WriteLine("\n===== Test Insert() =====");
			Jeux nouveauJeu = new Jeux
			{
				Nom = "Wakanda",
				Description = "Un jeu de tuiles stratégique",
				AgeMin = 7,
				AgeMax = 99,
				NbJoueurMin = 2,
				NbJoueurMax = 5,
				DureeMinute = 45
			};

			Guid newGameId = jeuxService.Insert(nouveauJeu);
			Console.WriteLine($"Jeu inséré avec succès =) Well done! ID: {newGameId}");

			Console.WriteLine("\n===== Test GetById() =====");
			Jeux jeuTrouve = jeuxService.GetById(newGameId);
			Console.WriteLine($"Jeu trouvé: {jeuTrouve.Nom} - {jeuTrouve.Description}");
		}

	}
}

