﻿
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Auth
{

	public class AuthRegisterForm
	{
		[Required]
		public string Pseudo { get; set; }

		[Required, DataType(DataType.Password)]
		public string MotDePasse { get; set; }

		[Required, DataType(DataType.Password), Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
		public string ConfirmMotDePasse { get; set; }
	}

}
