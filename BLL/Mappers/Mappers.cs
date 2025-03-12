﻿using BLL.Entities;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
	public static class Mappers
    {
		public static Utilisateur ToBLL(this D.Utilisateur utilisateur)
		{
			if (utilisateur == null) throw new ArgumentNullException(nameof(utilisateur));

			return new Utilisateur
			{
				Utilisateur_Id = utilisateur.Utilisateur_Id,
				Pseudo = utilisateur.Pseudo,
				MotDePasse = utilisateur.MotDePasse,
				DateCreation = utilisateur.DateCreation,
				DateDesactivation = utilisateur.DateDesactivation
			};
		}

		public static D.Utilisateur ToDAL(this Utilisateur utilisateur)
		{
			if (utilisateur == null) throw new ArgumentNullException(nameof(utilisateur));

			return new D.Utilisateur
			{
				Utilisateur_Id = utilisateur.Utilisateur_Id,
				Pseudo = utilisateur.Pseudo,
				MotDePasse = utilisateur.MotDePasse,
				DateCreation = utilisateur.DateCreation,
				DateDesactivation = utilisateur.DateDesactivation
			};
		}
	}
}
