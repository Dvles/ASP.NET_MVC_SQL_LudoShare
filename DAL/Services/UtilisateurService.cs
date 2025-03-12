using Common.Repositories;
using DAL.Entities;
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


	}
}
