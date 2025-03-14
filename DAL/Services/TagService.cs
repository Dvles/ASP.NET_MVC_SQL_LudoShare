using Common.Repositories;
using DAL.Entities;
using DAL.Mapper; // CHECK 
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
	public class TagService : ITagRepository<DAL.Entities.Tag>
	{
		private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_LudoShare;Integrated Security=True;";


		// Ajouter un tag
		public int Insert(string nom)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Tags_Insert";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@Tag", nom);

					connection.Open();
					return (int)command.ExecuteScalar(); // Récupère l'ID du tag inséré
				}
			}
		}
		// Récupérer tous les tags depuis la base de données
		public List<Tag> GetAll()
		{
			// Initialisation
			List<Tag> tags = new List<Tag>();

			// Ouverture de la connexion SQL
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					// On exécute la procédure stockée qui récupère tous les tags
					command.CommandText = "SP_Tags_GetAll";
					command.CommandType = CommandType.StoredProcedure;

					connection.Open(); 
					using (SqlDataReader reader = command.ExecuteReader()) // Exécution de la requête
					{
						// Lire chaque ligne retournée par la requête
						while (reader.Read())
						{
							// Ajouter un nouvel objet "Tag" à la liste
							tags.Add(new Tag
							{
								// Récupération de l'ID du tag (colonne 0, INT)
								Tag_Id = reader.GetInt32(0),

								// Récupération du nom du tag (colonne 1, NVARCHAR)
								Nom = reader.GetString(1)
							});
						}
					}
				}
			}

			// Retourner la liste de tags récupérés
			return tags;
		}

	}
}