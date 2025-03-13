using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Entities;
using ASP_MVC.Models;

namespace ASP_MVC.Controllers
{
	public class JeuxController : Controller
	{
		// Injection du service JeuxService  
		private readonly JeuxService _jeuxService;

		public JeuxController(JeuxService jeuxService)
		{
			_jeuxService = jeuxService; // Stocke l'instance pour utilisation  
		}

		// Fiche de jeu
		public IActionResult Details(Guid id)
		{
			var jeu = _jeuxService.GetById(id);
			if (jeu == null)
			{
				return NotFound();
			}
			ViewData["Title"] = $"Détails - {jeu.Nom}"; // Définition du titre dynamique
			return View(jeu);
		}

		// Ajouter jeu
		public IActionResult Ajouter()
		{
			ViewData["Title"] = "Ajouter un nouveau jeu"; // Définition du titre
			return View();
		}

		// Traitement du formulaire ajouteur jeu
		[HttpPost]
		public IActionResult Ajouter(JeuxCreateForm form)
		{
			// Vérifie si le formulaire est valide avant de traiter l'ajout du jeu
			if (!ModelState.IsValid)
			{
				ViewData["Title"] = "Ajouter un nouveau jeu"; // Garde le titre en cas d'erreur
				return View(form); // Renvoie le formulaire avec les erreurs
			}

			Jeux newJeu = new Jeux
			{
				Nom = form.Nom,
				Description = form.Description,
				AgeMin = form.AgeMin,
				AgeMax = form.AgeMax,
				NbJoueurMin = form.NbJoueurMin,
				NbJoueurMax = form.NbJoueurMax,
				DureeMinute = form.DureeMinute
			};

			_jeuxService.Insert(newJeu);

			return RedirectToAction("Index", "Home"); // Redirige vers l'accueil
		}
	}
}