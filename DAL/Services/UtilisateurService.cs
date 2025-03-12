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

		public Guid CheckPassword(string pseudo, string motDePasse)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_CheckPassword";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(pseudo), pseudo);
					command.Parameters.AddWithValue(nameof(motDePasse), motDePasse);
					connection.Open();
					return (Guid)command.ExecuteScalar();
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
					command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), utilisateur.Pseudo);
					command.Parameters.AddWithValue(nameof(Utilisateur.MotDePasse), utilisateur.MotDePasse);
					connection.Open();
					return (Guid)command.ExecuteScalar();
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
					command.ExecuteNonQuery();
				}
			}
		}

		public Utilisateur GetById(Guid utilisateur_id)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Utilisateur_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@UtilisateurId", utilisateur_id);

					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToUtilisateur();
						}
						else
						{
							throw new ArgumentOutOfRangeException(nameof(utilisateur_id));
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

	}
}
