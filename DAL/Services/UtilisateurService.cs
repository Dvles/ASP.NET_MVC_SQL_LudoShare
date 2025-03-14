using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UtilisateurService : IUtilisateurRepository<DAL.Entities.Utilisateur>
    {
		private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_LudoShare;Integrated Security=True;";

		public Guid CheckPassword(string email, string motDePasse)
		{
			using (SqlConnection connection = new SqlConnection(connectionString)) // Création de la connexion SQL
			{
				using (SqlCommand command = connection.CreateCommand()) // Création de la commande SQL
				{
					command.CommandText = "SP_Utilisateur_CheckPassword"; // Nom du stored procedure
					command.CommandType = CommandType.StoredProcedure; // Spécifie qu'on appelle un SP
					command.Parameters.AddWithValue(nameof(email), email); // Ajoute le paramètre "email"
					command.Parameters.AddWithValue(nameof(motDePasse), motDePasse); // Ajoute le paramètre "motDePasse"

					connection.Open(); // Ouvre la connexion à la base de données
					object result = command.ExecuteScalar(); // Exécute la requête et retourne la première colonne du premier enregistrement

					if (result == null || result == DBNull.Value)
					{
						return Guid.Empty; // Retourne un GUID vide si aucun utilisateur trouvé
					}

					return (Guid)result; // Retourne l'ID de l'utilisateur
				}
			}
		}

		public Guid Insert(Utilisateur utilisateur)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Insert";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Utilisateur.Email), utilisateur.Email);
					command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), utilisateur.Pseudo);
					command.Parameters.AddWithValue(nameof(Utilisateur.MotDePasse), utilisateur.MotDePasse);
					connection.Open();
					return (Guid)command.ExecuteScalar();  // Exécute la requête sans retour de valeur
				}
			}
		}

		public void UpdatePseudo(Guid utilisateurId, string nouveauPseudo)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_UpdatePseudo";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UtilisateurId", utilisateurId);
					command.Parameters.AddWithValue("@NouveauPseudo", nouveauPseudo);
					connection.Open();
					command.ExecuteNonQuery(); // Exécute la mise à jour et récupère le nombre de lignes affectées
				}
			}
		}
		public Utilisateur GetById(Guid utilisateurId)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UtilisateurId", utilisateurId);

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							Utilisateur user = reader.ToUtilisateur();

							// Check si l'utilisateur est désactivé
							if (user.DateDesactivation != null)
							{
								throw new Exception("Compte désactivé. Veuillez contacter le support.");
							}

							return user;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}

		public void Deactivate(Guid utilisateurId)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_Deactivate";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UtilisateurId", utilisateurId);
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery(); 

					if (rowsAffected == 0)
					{
						throw new Exception("Aucun utilisateur trouvé avec cet ID.");
					}
				}
			}
		}

		// TO REMOVE IF ALL WORKS FINE WITH CHECKPASSWORD
		//public Utilisateur? GetByEmail(string email)
		//{
		//	using (SqlConnection connection = new SqlConnection(connectionString))
		//	{
		//		using (SqlCommand command = connection.CreateCommand())
		//		{
		//			command.CommandText = "SP_Utilisateur_GetByEmail";
		//			command.CommandType = CommandType.StoredProcedure;
		//			command.Parameters.AddWithValue("@Email", email);
		//			connection.Open();
		//			using (SqlDataReader reader = command.ExecuteReader())
		//			{
		//				if (reader.Read())
		//				{
		//					return reader.ToUtilisateur();
		//				}
		//			}
		//		}
		//	}
		//	return null; // Retourne null si aucun utilisateur trouvé
		//}


	}
}
