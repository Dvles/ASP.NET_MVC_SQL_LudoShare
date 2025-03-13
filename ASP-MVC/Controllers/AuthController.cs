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

		public AuthController(UtilisateurService utilisateurService)
		{
			_utilisateurService = utilisateurService ?? throw new ArgumentNullException(nameof(utilisateurService));
		}

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

				Guid userId = _utilisateurService.CheckPassword(form.Pseudo, form.MotDePasse);

				if (userId != Guid.Empty)
				{
					HttpContext.Session.SetString("UserPseudo", form.Pseudo);
					HttpContext.Session.SetString("UserId", userId.ToString());

					return RedirectToAction("Index", "Home");
				}

				ViewBag.Error = "Pseudo ou mot de passe incorrect.";
				return View(form);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception in Connexion: {ex.Message}");
				ViewBag.Error = "Une erreur s'est produite : " + ex.Message;
				return View(form);
			}
		}




		// Déconnexion
		public ActionResult Deconnexion()
		{
			HttpContext.Session.Remove("UserPseudo");
			return RedirectToAction("Connexion");
		}


		// Inscription
		[HttpGet]
		public IActionResult Inscription()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Inscription(AuthRegisterForm form)
		{
			if (!ModelState.IsValid) return View(form);

			try
			{
				Utilisateur newUser = new Utilisateur
				{
					Pseudo = form.Pseudo,
					MotDePasse = form.MotDePasse // Hashing du mot de passe au niveau de la BD
				};

				Guid userId = _utilisateurService.Insert(newUser);

				if (userId != Guid.Empty)
				{
					HttpContext.Session.SetString("UserPseudo", form.Pseudo);
					HttpContext.Session.SetString("UserId", userId.ToString());

					return RedirectToAction("Index", "Home");
				}

				ViewBag.Error = "Erreur lors de l'inscription.";
			}
			catch (Exception ex)
			{
				ViewBag.Error = "Une erreur s'est produite : " + ex.Message;
			}

			return View(form);
		}

	}
}
