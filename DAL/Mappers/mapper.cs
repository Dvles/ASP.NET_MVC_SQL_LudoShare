using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
	public static class Mapper
	{
		public static Utilisateur ToUtilisateur(this IDataRecord record)
		{
			if (record is null) throw new ArgumentNullException(nameof(record));

			return new Utilisateur()
			{
				Utilisateur_Id = (Guid)record[nameof(Utilisateur.Utilisateur_Id)],
				Pseudo = (string)record[nameof(Utilisateur.Pseudo)],
				Salt = (Guid)record[nameof(Utilisateur.Salt)],
				DateCreation = (DateTime)record[nameof(Utilisateur.DateCreation)],
				DateDesactivation = record[nameof(Utilisateur.DateDesactivation)] is DBNull
					? null
					: (DateTime?)record[nameof(Utilisateur.DateDesactivation)]
			};
		}
	}
}

