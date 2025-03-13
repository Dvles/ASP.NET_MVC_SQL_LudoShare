using BLL.Services;
using BLL.Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Models;

namespace ASP_MVC.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger; // voir logs et débuger
	private readonly JeuxService _jeuxService; // injection du service BLL

	public HomeController(ILogger<HomeController> logger, JeuxService jeuxService)
	{
		_logger = logger;
		_jeuxService = jeuxService;
	}

	public IActionResult Index()
	{
		_logger.LogInformation("Chargement des jeux pour la page d'accueil.");
		var jeux = _jeuxService.GetAll();
		return View(jeux);
	}

	public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
