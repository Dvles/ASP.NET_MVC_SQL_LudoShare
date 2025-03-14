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

				if (_utilisateurService == null)
				{
					throw new Exception("_utilisateurService is NOT initialized! Check dependency injection.");
				}

				// Vérification des identifiants → Retourne un GUID (ou Guid.Empty si invalide OU désactivé)
				Guid userId = _utilisateurService.CheckPassword(form.Email, form.MotDePasse);

				if (userId == Guid.Empty)
				{
					// Identifiants invalides ou compte désactivé
					ViewBag.Error = "Email ou mot de passe incorrect, ou compte désactivé.";
					return View(form);
				}

				// Connexion réussie → stocker dans la session
				HttpContext.Session.SetString("UserEmail", form.Email);
				HttpContext.Session.SetString("UserId", userId.ToString());

				return RedirectToAction("Index", "Home");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception in Connexion: {ex.Message}");
				ViewBag.Error = "Une erreur s'est produite : " + ex.Message;
				return View(form);
			}
		}





		// Déconnexion et suppression de la session
		public ActionResult Deconnexion()
		{
			HttpContext.Session.Remove("UserPseudo");
			return RedirectToAction("Connexion");
		}

	}
}
