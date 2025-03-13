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

			// Ajoute le support des contr�leurs et des vues MVC
			builder.Services.AddControllersWithViews();

			// Configuration de la gestion des sessions
			builder.Services.AddSession(options => {
				options.Cookie.Name = "CookieWad24";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.IdleTimeout = TimeSpan.FromMinutes(10);
			});

			// Ajoute l'acc�s au contexte HTTP pour r�cup�rer des informations utilisateur dans les services
			builder.Services.AddHttpContextAccessor();

			/// Injection du service de la DAL et BLL :
			// Associe l'interface g�n�rique � la classe associ�e
			builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>(); // service g�rant directement les requ�tes SQL et l'acc�s � la base de donn�es

			builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>(); // service agissant comme un interm�diaire entre le contr�leur et la DAL

			builder.Services.AddScoped<BLL.Services.UtilisateurService>(); // Injection directe du service BLL pour �viter d'avoir � le r�soudre via l'interface

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
