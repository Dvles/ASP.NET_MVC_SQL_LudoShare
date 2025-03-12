using BLL.Mapper;
using B = BLL.Entities;
using Common.Repositories;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services
{
	public class UtilisateurService: IUtilisateurRepository<Utilisateur>
    {
		private IUtilisateurRepository<D.Utilisateur> _utilisateurService;

		public UtilisateurService(IUtilisateurRepository<D.Utilisateur> utilisateurService
			)
		{
			_utilisateurService = utilisateurService;
		}

		public Guid CheckPassword(string pseudo, string motDePasse)
		{
			return _utilisateurService.CheckPassword(pseudo, motDePasse);
		}

		public Guid Insert(Utilisateur utilisateur)
		{
			return _utilisateurService.Insert(utilisateur.ToDAL());
		}

		public void UpdatePseudo(Guid utilisateur_id, string pseudo)
		{
			_utilisateurService.UpdatePseudo(utilisateur_id, pseudo);
		}

		public BLL.Entities.Utilisateur GetById(Guid utilisateur_id)
		{
			return _utilisateurService.GetById(utilisateur_id).ToBLL();
		}

		public void Deactivate(Guid utilisateur_id)
		{
			_utilisateurService.Deactivate(utilisateur_id);
		}




	}
}
