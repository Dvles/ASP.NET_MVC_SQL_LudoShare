using System;
using System.Collections.Generic;
using Common.Repositories;
using B = BLL.Entities; 
using D = DAL.Entities; 

namespace FakeRepository
{
	public class FakeUtilisateurRepository : IUtilisateurRepository<B.Utilisateur> 
	{
		private readonly List<B.Utilisateur> _utilisateurs = new();

		public Guid CheckPassword(string pseudo, string motDePasse)
		{
			var user = _utilisateurs.Find(u => u.Pseudo == pseudo && u.MotDePasse == motDePasse);
			return user != null ? user.Utilisateur_Id : Guid.Empty;
		}

		public Guid Insert(B.Utilisateur utilisateur)
		{
			utilisateur.Utilisateur_Id = Guid.NewGuid();
			_utilisateurs.Add(utilisateur);
			return utilisateur.Utilisateur_Id;
		}

		public void UpdatePseudo(Guid utilisateurId, string nouveauPseudo)
		{
			var user = _utilisateurs.Find(u => u.Utilisateur_Id == utilisateurId);
			if (user != null)
			{
				user.Pseudo = nouveauPseudo;
			}
		}

		public B.Utilisateur GetById(Guid utilisateurId)
		{
			return _utilisateurs.Find(u => u.Utilisateur_Id == utilisateurId);
		}

		public void Deactivate(Guid utilisateurId)
		{
			var user = _utilisateurs.Find(u => u.Utilisateur_Id == utilisateurId);
			if (user != null)
			{
				user.DateDesactivation = DateTime.Now;
			}
		}
	}
}
