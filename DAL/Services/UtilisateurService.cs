using Common.Repositories;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UtilisateurService //: IUtilisateurRepository
    {
		private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_LudoShare;Integrated Security=True;";

		//public Guid CheckPassword(string pseudo, string motDePasse)
		//{
		//	using (SqlConnection connection = new SqlConnection(connectionString))
		//	{
		//		using (SqlCommand command = connection.CreateCommand())
		//		{
		//			command.CommandText = "";
		//			command.CommandType = CommandType.StoredProcedure;
		//			command.Parameters.AddWithValue(nameof(pseudo), pseudo);
		//			command.Parameters.AddWithValue(nameof(motDePasse), motDePasse);
		//			connection.Open();
		//			return (Guid)command.ExecuteScalar();
		//		}
		//	}

		//}



	}
}
