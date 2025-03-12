using System;
using DAL.Entities;
using DAL.Services; // Assure-toi d'ajouter cette ligne pour utiliser ton service

namespace ConsoleTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			

			UtilisateurService utilisateurService = new UtilisateurService();
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

		}
	}
}
