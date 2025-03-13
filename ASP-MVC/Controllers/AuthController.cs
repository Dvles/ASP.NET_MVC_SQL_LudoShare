using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Services;
using BLL.Entities;
using Common.Repositories;
using ASP_MVC.Models.Auth;

namespace ASP_MVC.Controllers
{
	public class AuthController : Controller
	{
		private readonly UtilisateurService _utilisateurService;

		// Injection du service utilisateur (BLL)
		public AuthController(UtilisateurService utilisateurService)
		{
			_utilisateurService = utilisateurService ?? throw new ArgumentNullException(nameof(utilisateurService));
		}

		// Connexion
		[HttpGet]
		public IActionResult Connexion()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Connexion(AuthLoginForm form)
		{
			try
			{
				if (!ModelState.IsValid) return View(form);

				// Debug log: Check if _utilisateurService is null
				Console.WriteLine($"_utilisateurService est null ? {_utilisateurService == null}");

				if (_utilisateurService == null)
				{
					throw new Exception("_utilisateurService is NOT initialized! Check dependency injection.");
				}

				// Vérification des identifiants
				Guid userId = _utilisateurService.CheckPassword(form.Pseudo, form.MotDePasse);

				// Connexion réussie → stocker dans la session
				if (userId != Guid.Empty)
				{
					HttpContext.Session.SetString("UserPseudo", form.Pseudo);
					HttpContext.Session.SetString("UserId", userId.ToString());

					return RedirectToAction("Index", "Home");
				}

				// Identifiants invalides
				ViewBag.Error = "Pseudo ou mot de passe incorrect.";
				return View(form);
			}
			catch (Exception ex)
			{
				// Gestion des erreurs
				Console.WriteLine($"Exception in Connexion: {ex.Message}");
				ViewBag.Error = "Une erreur s'est produite : " + ex.Message;
				return View(form);
			}
		}


		// Déconnexion et suppression de la session
		public ActionResult Deconnexion()
		{
			HttpContext.Session.Remove("UserPseudo"); // (à config)
			return RedirectToAction("Connexion");
		}

	}
}
