using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
	public class JeuxService : IJeuxRepository<Jeux>
	{
		private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_LudoShare;Integrated Security=True;";

		public IEnumerable<Jeux> GetAll()
		{
			List<Jeux> jeuxList = new List<Jeux>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeux_GetAll";
					command.CommandType = CommandType.StoredProcedure;

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToJeux();
						}
					}
				}
			}
		}
		public Jeux GetById(Guid jeuxId)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeux_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@Jeux_Id", jeuxId);

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToJeux();
						}
						else
						{
							throw new KeyNotFoundException($"Aucun jeu trouvé avec l'ID {jeuxId}");
						}
					}
				}
			}
		}
		public Guid Insert(Jeux jeu)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Jeux_Insert";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@Nom", jeu.Nom);
					command.Parameters.AddWithValue("@Description", jeu.Description);
					command.Parameters.AddWithValue("@AgeMin", jeu.AgeMin);
					command.Parameters.AddWithValue("@AgeMax", jeu.AgeMax);
					command.Parameters.AddWithValue("@NbJoueurMin", jeu.NbJoueurMin);
					command.Parameters.AddWithValue("@NbJoueurMax", jeu.NbJoueurMax);
					command.Parameters.AddWithValue("@DureeMinute", jeu.DureeMinute);

					connection.Open();
					return (Guid)command.ExecuteScalar();  // Récupère l'ID généré
				}
			}
		}
	}

}
