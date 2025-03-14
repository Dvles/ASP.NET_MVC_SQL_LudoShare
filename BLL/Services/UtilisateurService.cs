﻿using BLL.Mappers;
using B = BLL.Entities;
using Common.Repositories;
using D = DAL.Entities;
using System;

namespace BLL.Services
{
	/// Service métier pour la gestion des utilisateurs, faisant le lien entre la BLL et la DAL.  

	public class UtilisateurService : IUtilisateurRepository<B.Utilisateur>
	{


		// Référence au dépôt d'accès aux données des utilisateurs (DAL).  
		private readonly IUtilisateurRepository<D.Utilisateur> _utilisateurRepository;

		// Constructeur qui injecte le dépôt d'utilisateurs (DAL) pour gérer l'accès aux données (facilite modularité (remplacement implémentation) + test unitaire).
		public UtilisateurService(IUtilisateurRepository<D.Utilisateur> utilisateurRepository)
		{
			_utilisateurRepository = utilisateurRepository;
		}

		public Guid CheckPassword(string email, string motDePasse)
		{
			return _utilisateurRepository.CheckPassword(email, motDePasse);
		}

		public Guid Insert(B.Utilisateur utilisateur)
		{
			
			return _utilisateurRepository.Insert(utilisateur.ToDAL());
		}

		public void UpdatePseudo(Guid utilisateur_id, string pseudo)
		{
			_utilisateurRepository.UpdatePseudo(utilisateur_id, pseudo);
		}

		public B.Utilisateur GetById(Guid utilisateur_id)
		{
			return _utilisateurRepository.GetById(utilisateur_id)?.ToBLL();
		}

		public void Deactivate(Guid utilisateur_id)
		{
			_utilisateurRepository.Deactivate(utilisateur_id);
		}
	}
}
