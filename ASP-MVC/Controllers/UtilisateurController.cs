using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Entities;
using ASP_MVC.Models.Utilisateur;
using System;

namespace ASP_MVC.Controllers
{
	public class UtilisateurController : Controller
	{
		private readonly UtilisateurService _utilisateurService;

		public UtilisateurController(UtilisateurService utilisateurService)
		{
			_utilisateurService = utilisateurService ?? throw new ArgumentNullException(nameof(utilisateurService));
		}
		// inscription 
		[HttpGet]
		public IActionResult Inscription()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Inscription(UtilisateurCreateForm form)
		{
			if (!ModelState.IsValid) return View(form);

			try
			{
				Guid userId = _utilisateurService.Insert(new Utilisateur
				{
					Pseudo = form.Pseudo,
					MotDePasse = form.MotDePasse
				});

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


		// détails profil

		[HttpGet]
		public IActionResult Profil()
		{
			// Récupérer l'ID de l'utilisateur connecté depuis la session
			string? userIdString = HttpContext.Session.GetString("UserId");
			if (string.IsNullOrEmpty(userIdString))
			{
				return RedirectToAction("Connexion", "Auth"); // Rediriger vers la connexion si non connecté
			}

			Guid userId = Guid.Parse(userIdString);
			Utilisateur utilisateur = _utilisateurService.GetById(userId);

			if (utilisateur == null)
			{
				return RedirectToAction("Connexion", "Auth");
			}

			return View(utilisateur);
		}

		// modifier pseudo
		[HttpGet]
		public IActionResult ModifierPseudo()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ModifierPseudo(string nouveauPseudo)
		{
			if (string.IsNullOrWhiteSpace(nouveauPseudo))
			{
				ViewBag.Error = "Le pseudo ne peut pas être vide.";
				return View();
			}

			try
			{
				Guid userId = Guid.Parse(HttpContext.Session.GetString("UserId")!);
				_utilisateurService.UpdatePseudo(userId, nouveauPseudo);
				HttpContext.Session.SetString("UserPseudo", nouveauPseudo);

				ViewBag.Success = "Votre pseudo a été mis à jour avec succès.";
			}
			catch (Exception ex)
			{
				ViewBag.Error = "Une erreur s'est produite : " + ex.Message;
			}

			return View();
		}

		// Soft Delete

		[HttpGet]
		public IActionResult DesactiverCompte()
		{
			return View();
		}

		[HttpPost]
		public IActionResult DesactiverCompteConfirmation()
		{
			try
			{
				// Récupération de l'ID de l'utilisateur connecté
				if (!Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid userId))
				{
					return RedirectToAction("Connexion", "Auth"); // Redirige vers la connexion si l'ID est introuvable
				}

				// Désactiver l'utilisateur
				_utilisateurService.Deactivate(userId);

				// Suppression de la session (déconnexion)
				HttpContext.Session.Clear();

				return RedirectToAction("Connexion", "Auth");
			}
			catch (Exception ex)
			{
				ViewBag.Error = "Une erreur s'est prodiute : " + ex.Message;
				return View("DesactiverCompte");
			}
		}



	}
}
