using DAL.Entities;
using Common.Repositories;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
	public class UtilisateurService : IUtilisateurRepository<Utilisateur, Guid>
	{
		private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_LudoShare;Integrated Security=True;";

		public Guid CheckPassword(string pseudo, string password)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT Utilisateur_Id, MotDePasse, Salt FROM Utilisateur WHERE Pseudo = @Pseudo";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@Pseudo", pseudo);
					command.Parameters.AddWithValue("@MotDePasse", password);
					connection.Open();

					object result = command.ExecuteScalar();
					if (result != null && result is Guid userId)
					{
						return userId;
					}
				}
			}
			throw new UnauthorizedAccessException("Invalid credentials.");
		}

		public Utilisateur GetById(Guid id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT Utilisateur_Id, Pseudo, DateCreation, DateDesactivation FROM Utilisateur WHERE Utilisateur_Id = @Id";
					command.Parameters.AddWithValue("@Id", id);
					connection.Open();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToUtilisateur();
						}
					}
				}
			}
			throw new KeyNotFoundException("User not found.");
		}

		public Guid Insert(Utilisateur user)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "INSERT INTO Utilisateur (Utilisateur_Id, Pseudo, MotDePasse, DateCreation) OUTPUT INSERTED.Utilisateur_Id VALUES (@Id, @Pseudo, @MotDePasse, GETDATE())";
					command.Parameters.AddWithValue("@Id", user.Utilisateur_Id);
					command.Parameters.AddWithValue("@Pseudo", user.Pseudo);
					command.Parameters.AddWithValue("@MotDePasse", user.MotDePasse); // Plain password (DB handles hashing)
					connection.Open();

					return (Guid)command.ExecuteScalar();
				}
			}
		}



		public void UpdatePseudo(Guid id, string newPseudo)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "UPDATE Utilisateur SET Pseudo = @Pseudo WHERE Utilisateur_Id = @Id";
					command.Parameters.AddWithValue("@Pseudo", newPseudo);
					command.Parameters.AddWithValue("@Id", id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public void Deactivate(Guid id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "UPDATE Utilisateur SET DateDesactivation = GETDATE() WHERE Utilisateur_Id = @Id";
					command.Parameters.AddWithValue("@Id", id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
