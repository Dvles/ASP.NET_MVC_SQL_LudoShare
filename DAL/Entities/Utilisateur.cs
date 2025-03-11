using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
	public class Utilisateur
	{
		[Key]
		public Guid Utilisateur_Id { get; set; } = Guid.NewGuid();

		[Required]
		public byte[] MotDePasse { get; set; }

		[Required]
		public Guid Salt { get; set; }

		[Required]
		[MaxLength(64)]
		public string Pseudo { get; set; }

		[Required]
		public DateTime DateCreation { get; set; } = DateTime.UtcNow;

		public DateTime? DateDesactivation { get; set; }
	}
}
