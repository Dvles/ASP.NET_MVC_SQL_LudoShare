﻿using BLL.Entities;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
	/// Convertit les entités entre BLL et DAL.
	public static class Mappers
    {
		// Convertit un utilisateur DAL en BLL en mappant ses propriétés
		public static Utilisateur ToBLL(this D.Utilisateur utilisateur)
		{
			// Check si l'utilisateur est null et lève une exception si c'est le cas
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

		// Convertit un utilisateur BLL en DAL en mappant ses propriétés.
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

		// Convertit un utilisateur DAL en BLL en mappant ses propriétés

		public static Jeux ToBLL(this DAL.Entities.Jeux jeu)
		{
			return new Jeux
			{
				Jeux_Id = jeu.Jeux_Id,
				Nom = jeu.Nom,
				Description = jeu.Description,
				AgeMin = jeu.AgeMin,
				AgeMax = jeu.AgeMax,
				NbJoueurMin = jeu.NbJoueurMin,
				NbJoueurMax = jeu.NbJoueurMax,
				DureeMinute = jeu.DureeMinute,
				DateCreation = jeu.DateCreation
			};
		}
		// Convertit un utilisateur BLL en DAL en mappant ses propriétés.

		public static DAL.Entities.Jeux ToDAL(this Jeux jeu)
		{
			return new DAL.Entities.Jeux
			{
				Jeux_Id = jeu.Jeux_Id,
				Nom = jeu.Nom,
				Description = jeu.Description,
				AgeMin = jeu.AgeMin,
				AgeMax = jeu.AgeMax,
				NbJoueurMin = jeu.NbJoueurMin,
				NbJoueurMax = jeu.NbJoueurMax,
				DureeMinute = jeu.DureeMinute,
				DateCreation = jeu.DateCreation
			};
		}
	}
}

