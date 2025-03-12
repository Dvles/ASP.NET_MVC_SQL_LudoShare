using BLL.Entities;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
	internal static class Mappers
    {
		public static Utilisateur ToBLL(this D.Utilisateur utilisateur)
		{
			if (utilisateur is null) throw new ArgumentNullException(nameof(utilisateur));
			return new Utilisateur(
				utilisateur.Utilisateur_Id,
				utilisateur.Pseudo,
				utilisateur.DateCreation,
				utilisateur.DateDesactivation
			);
		}

		public static D.Utilisateur ToDAL(this Utilisateur utilisateur)
		{
			if (utilisateur is null) throw new ArgumentNullException(nameof(utilisateur));
			return new D.Utilisateur()
			{
				Utilisateur_Id = utilisateur.Utilisateur_Id,
				Pseudo = utilisateur.Pseudo,
				DateCreation = utilisateur.DateCreation,
				DateDesactivation = utilisateur.DateDesactivation
			};
		}
	}
}
