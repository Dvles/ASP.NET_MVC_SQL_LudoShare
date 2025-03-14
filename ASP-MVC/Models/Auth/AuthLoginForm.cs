﻿using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Auth
{
	public class AuthLoginForm
	{
		[Required]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string MotDePasse { get; set; }
	}
}