using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Utilisateur
    {
		public Guid Utilisateur_Id { get; set; }
		public string Email { get; set; }
		public string Pseudo { get; set; }
		public string MotDePasse { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime? DateDesactivation { get; set; }
	}
}
