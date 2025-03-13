using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Logout()
		{
			HttpContext.Session.Clear(); // Supprime toutes les infos de session
			return RedirectToAction("Connexion", "Auth");
		}

	}
}
