using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Entities;

namespace ASP_MVC.Controllers
{
	public class JeuxController : Controller
	{
		private readonly JeuxService _jeuxService;

		public JeuxController(JeuxService jeuxService)
		{
			_jeuxService = jeuxService;
		}

		public IActionResult Details(Guid id)
		{
			var jeu = _jeuxService.GetById(id);
			if (jeu == null)
			{
				return NotFound();
			}
			return View(jeu);
		}
	}
}