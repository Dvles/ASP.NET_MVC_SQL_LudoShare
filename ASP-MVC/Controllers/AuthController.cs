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
		private readonly IUtilisateurRepository<BLL.Entities.Utilisateur> _utilisateurService;

		public AuthController(IUtilisateurRepository<BLL.Entities.Utilisateur> utilisateurService)
		{
			_utilisateurService = utilisateurService;
		}


		// Afficher le formulaire d'inscription
		public ActionResult Inscription()
		{
			return View();
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
	}
}
