using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
     public interface IUtilisateurRepository<TUtilisateur>
    {
		
		Guid CheckPassword(string pseudo, string motdepasse);
		public Guid Insert(TUtilisateur utilisateur);
		public void UpdatePseudo(Guid utilisateurId, string nouveauPseudo);

	}
}
