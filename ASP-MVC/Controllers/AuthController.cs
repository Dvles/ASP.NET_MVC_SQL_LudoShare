using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Services;
using BLL.Entities;
using Common.Repositories;

namespace ASP_MVC.Controllers
{
	public class AuthController : Controller
	{
		private readonly UtilisateurService _utilisateurService;

		public AuthController(UtilisateurService utilisateurService)
		{
			_utilisateurService = utilisateurService;
		}

		// Afficher le formulaire d'inscription
		public ActionResult Inscription()
		{
			return View();
		}

		// Traiter l'inscription
		[HttpPost]
		public ActionResult Inscription(Utilisateur model)
		{
			if (ModelState.IsValid)
			{
				model.Utilisateur_Id = Guid.NewGuid();
				model.DateCreation = DateTime.Now;

				_utilisateurService.Insert(model); // Ajouter en DB

				return RedirectToAction("Connexion");
			}

			return View(model);
		}
	}
}
