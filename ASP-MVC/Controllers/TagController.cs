using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Entities;
using ASP_MVC.Models;

namespace ASP_MVC.Controllers
{

	public class TagController : Controller
	{
		private readonly TagService _tagService;  

		
		public TagController(TagService tagService)
		{
			_tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
		}


		public IActionResult Ajouter()
		{
			return View();
		}

		
		[HttpPost]
		public IActionResult Ajouter(string tagName)
		{
			// Vérifie si le nom du tag est vide ou null
			if (string.IsNullOrEmpty(tagName))
			{
				// ajoute une erreur au modèle
				ModelState.AddModelError("", "Le nom du tag ne peut être vide.");
				return View();
			}

			var tagId = _tagService.Insert(tagName);

			// Vérifie si l'insertion a réussi 
			if (tagId > 0)
			{
				TempData["SuccessMessage"] = "Bravo! Nouveau tag ajouté!";
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Le tag n'a pas pu être ajouté.");
				return View();
			}
		}
	}

}
