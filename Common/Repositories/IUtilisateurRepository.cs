using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface IUtilisateurRepository<TEntity, TId>
	{
		TId CheckPassword(string pseudo, string password);
		TEntity GetById(TId id);
		TId Insert(TEntity entity);
		void UpdatePseudo(TId id, string newPseudo);
		void Deactivate(TId id); 
	}
}

