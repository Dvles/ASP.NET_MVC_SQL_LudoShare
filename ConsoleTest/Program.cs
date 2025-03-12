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
							Pseudo = "Lili",
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

			Guid utilisateurId = new Guid("88480a21-6666-48ba-9bac-6b0ed6d8c710"); 
			string nouveauPseudo = "NewLili"; 

			try
			{
				utilisateurService.UpdatePseudo(utilisateurId, nouveauPseudo);
				Console.WriteLine($"✅ Pseudo mis à jour pour:  {utilisateurId} !");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Erreur: {ex.Message}");
			}


		}
	}
}
