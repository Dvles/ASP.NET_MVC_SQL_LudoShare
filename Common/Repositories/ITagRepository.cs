using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ITagRepository<TTag>
	{
		public int Insert(string nom);
		public List<TTag> GetAll();


	}
}
