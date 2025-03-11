using DAL.Entities;
using DAL.Services;
using System;

namespace ConsoleTest2
{
	class Program
	{
		static void Main(string[] args)
		{
			UtilisateurService userService = new UtilisateurService();

			Utilisateur newUser = new Utilisateur
			{
				Pseudo = "TestUser",
				MotDePasse = "SecurePassword123" 
			};

			Guid userId = userService.Insert(newUser);
			Console.WriteLine($"Inserted User ID: {userId}");


		}
	}
}