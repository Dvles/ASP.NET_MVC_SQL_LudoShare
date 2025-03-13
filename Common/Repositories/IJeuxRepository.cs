using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface IJeuxRepository<TJeux>
	{
		IEnumerable<TJeux> GetAll();
		TJeux GetById(Guid jeuxId);
		Guid Insert(TJeux jeu);
	}
}
