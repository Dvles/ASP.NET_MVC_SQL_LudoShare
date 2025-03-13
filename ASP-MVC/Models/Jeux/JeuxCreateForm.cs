using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models
{
	public class JeuxCreateForm
	{
		[Required(ErrorMessage = "Le nom est requis")]
		[StringLength(64, ErrorMessage = "Le nom ne doit pas dépasser 64 caractères")]
		public string Nom { get; set; } = default!;

		[Required(ErrorMessage = "La description est requise")]
		[StringLength(512, ErrorMessage = "La description ne doit pas dépasser 512 caractères")]
		public string Description { get; set; } = default!;

		[Required(ErrorMessage = "L'âge minimum est requis")]
		[Range(0, 99, ErrorMessage = "L'âge minimum doit être compris entre 0 et 99")]
		public int AgeMin { get; set; }

		[Required(ErrorMessage = "L'âge maximum est requis")]
		[Range(1, 99, ErrorMessage = "L'âge maximum doit être compris entre 1 et 99")]
		public int AgeMax { get; set; }

		[Required(ErrorMessage = "Le nombre minimum de joueurs est requis")]
		[Range(1, 20, ErrorMessage = "Le nombre minimum de joueurs doit être compris entre 1 et 20")]
		public int NbJoueurMin { get; set; }

		[Required(ErrorMessage = "Le nombre maximum de joueurs est requis")]
		[Range(1, 20, ErrorMessage = "Le nombre maximum de joueurs doit être compris entre 1 et 20")]
		public int NbJoueurMax { get; set; }

		[Required(ErrorMessage = "La durée est requise")]
		[Range(1, 240, ErrorMessage = "La durée doit être comprise entre 1 et 240 minutes")]
		public int DureeMinute { get; set; }
	}
}
