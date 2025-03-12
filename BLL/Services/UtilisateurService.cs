using BLL.Mappers;
using B = BLL.Entities;
using Common.Repositories;
using D = DAL.Entities;
using System;

namespace BLL.Services
{
	public class UtilisateurService : IUtilisateurRepository<B.Utilisateur>
	{
		private readonly IUtilisateurRepository<D.Utilisateur> _utilisateurRepository;

		public UtilisateurService(IUtilisateurRepository<D.Utilisateur> utilisateurRepository)
		{
			_utilisateurRepository = utilisateurRepository;
		}

		public Guid CheckPassword(string pseudo, string motDePasse)
		{
			return _utilisateurRepository.CheckPassword(pseudo, motDePasse);
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
