using BLL.Services;
using BLL.Entities;
using DAL.Entities;
using DAL.Services;
using Common.Repositories;

namespace ASP_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Ajoute le support des contrôleurs et des vues MVC
			builder.Services.AddControllersWithViews();

			// Configuration de la gestion des sessions
			builder.Services.AddSession(options => {
				options.Cookie.Name = "CookieWad24";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.IdleTimeout = TimeSpan.FromMinutes(10);
			});

			// Ajoute l'accès au contexte HTTP pour récupérer des informations utilisateur dans les services
			builder.Services.AddHttpContextAccessor();

			/// Injection du service de la DAL et BLL :
			// Associe l'interface générique à la classe associée
			builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>(); // service gèrant directement les requêtes SQL et l'accès à la base de données

			builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>(); // service agissant comme un intermédiaire entre le contrôleur et la DAL

			builder.Services.AddScoped<BLL.Services.UtilisateurService>(); // Injection directe du service BLL pour éviter d'avoir à le résoudre via l'interface

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles(); // Activation des fichiers statiques (CSS, JS, images, etc.)
			app.UseRouting(); // Configuration du routage MVC
			app.UseSession();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
