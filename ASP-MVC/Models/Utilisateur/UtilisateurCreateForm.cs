using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Utilisateur
{
	public class UtilisateurCreateForm
	{

		[Required(ErrorMessage = "Le champ 'Email' est obligatoire.")]
		[EmailAddress]

		public string Email { get; set; }

		[Required(ErrorMessage = "Le champ 'Pseudo' est obligatoire.")]
		public string Pseudo { get; set; }

		[Required, DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum 8 caractères.")]
		[MaxLength(32, ErrorMessage = "Le champ 'Mot de passe' doit contenir au maximum 32 caractères.")]
		[RegularExpression(@"^.*(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\-_+=\.()\[\]$µ£\\/*§?{}]).*", ErrorMessage = "Le champ 'Mot de passe' doit contenir au minimum une minuscule, une majuscule, un chiffre et un symbole.")]
		public string MotDePasse { get; set; }

		[Required, DataType(DataType.Password), Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
		public string ConfirmMotDePasse { get; set; }

		// Bonne pratique: inclure a consent form; public bool Consent { get; set; }
	}
}

