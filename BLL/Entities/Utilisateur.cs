using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Utilisateur
	{
		public Guid Utilisateur_Id { get; set; }
		public string Pseudo { get; set; }
		public string MotDePasse { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime? DateDesactivation { get; set; }

		public Utilisateur(Guid utilisateur_Id, string pseudo, DateTime dateCreation, DateTime? dateDesactivation)
		{
			Utilisateur_Id = utilisateur_Id;
			Pseudo = pseudo;
			DateCreation = dateCreation;
			DateDesactivation = dateDesactivation;
		}


		//  Constructeur sans paramètres pour la sérialisation et le mapping automatique (BLL/Mappers) - pour flexibilité
		public Utilisateur() { }
	}
}
