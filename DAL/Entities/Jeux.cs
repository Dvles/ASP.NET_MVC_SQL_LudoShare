using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Jeux
	{
		public Guid Jeux_Id { get; set; } 
		public string Nom { get; set; } 
		public string Description { get; set; } 
		public byte AgeMin { get; set; } 
		public byte AgeMax { get; set; }
		public byte NbJoueurMin { get; set; } 
		public byte NbJoueurMax { get; set; } 
		public short DureeMinute { get; set; }
		public DateTime DateCreation { get; set; } 

		public Jeux()
		{
			DateCreation = DateTime.Now; 
		}
	}
}