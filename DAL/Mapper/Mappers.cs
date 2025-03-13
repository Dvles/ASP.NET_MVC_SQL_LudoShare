using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
	internal static class Mappers
	{


		///  Convertit un enregistrement de la base de données (record) en objet Utilisateur, avec gestion des valeurs null.  

		public static Utilisateur ToUtilisateur(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));

			return new Utilisateur()
			{
				Utilisateur_Id = (Guid)record["Utilisateur_Id"],
				Pseudo = (string)record["Pseudo"],
				DateCreation = (DateTime)record["DateCreation"],
				DateDesactivation = record["DateDesactivation"] is DBNull ? null : (DateTime?)record["DateDesactivation"]
			};

		}
	}
}
