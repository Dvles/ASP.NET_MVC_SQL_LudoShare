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

			builder.Services.AddControllersWithViews();
			builder.Services.AddSession(options => {
				options.Cookie.Name = "CookieWad24";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.IdleTimeout = TimeSpan.FromMinutes(10);
			});

			builder.Services.AddHttpContextAccessor();

			// Explicitly specify DAL.UtilisateurService
			builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>();

			// Explicitly specify BLL.UtilisateurService
			builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>();
			builder.Services.AddScoped<BLL.Services.UtilisateurService>();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseRouting();
			app.UseSession();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
