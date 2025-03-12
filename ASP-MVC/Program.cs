using BLL.Services;
using BLL.Entities;
using DAL.Entities;
using Common.Repositories;

namespace ASP_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			// Ajout du service de session
			builder.Services.AddSession(options => {
				options.Cookie.Name = "CookieWad24";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.IdleTimeout = TimeSpan.FromMinutes(10);
			});

			// Ajout des services liés aux utilisateurs
			builder.Services.AddScoped<UtilisateurService>(); // Injection directe de la BLL
			builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>();
			builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>();

			// Ajout de HttpContextAccessor pour les sessions
			builder.Services.AddHttpContextAccessor();





			var app = builder.Build();



			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");


			app.Run();
		}
	}
}
