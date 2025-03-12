using System;
using DAL.Services; // Assure-toi d'ajouter cette ligne pour utiliser ton service

namespace ConsoleTest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== Test de l'authentification ===");

			// Instancier le service
			UtilisateurService utilisateurService = new UtilisateurService();

			// Données fictives (assure-toi qu'elles existent en BDD)
			string pseudo = "MonPseudo";
			string motDePasse = "MonMotDePasse";

			// Tester la connexion
			Guid userId = utilisateurService.CheckPassword(pseudo, motDePasse);

			// Vérifier le résultat
			if (userId == Guid.Empty)
			{
				Console.WriteLine("❌ Échec de l'authentification : pseudo ou mot de passe incorrect.");
			}
			else
			{
				Console.WriteLine($"✅ Authentification réussie ! User ID : {userId}");
			}

			// Attendre l'entrée utilisateur pour voir le résultat avant que la console ne se ferme
			Console.WriteLine("Appuyez sur une touche pou
