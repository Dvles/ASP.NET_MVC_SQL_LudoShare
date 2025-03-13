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
	}
}