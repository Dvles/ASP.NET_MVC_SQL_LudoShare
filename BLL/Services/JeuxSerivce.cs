using System;
using System.Collections.Generic;
using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using DAL.Services;

namespace BLL.Services
{
	public class JeuxService : IJeuxRepository<Jeux>
	{
		// Dépendance vers la DAL via une interface (permet de réduire le couplage(Niveau de dépendante entre composant) et d'améliorer la testabilité).  
		private readonly IJeuxRepository<DAL.Entities.Jeux> _dalService;


		// Injection de dépendance via le constructeur (évite l'instanciation directe et facilite les tests unitaires).  
		public JeuxService(IJeuxRepository<DAL.Entities.Jeux> dalService)
		{
			_dalService = dalService ?? throw new ArgumentNullException(nameof(dalService));
		}

		public IEnumerable<Jeux> GetAll()
		{
			foreach (var jeu in _dalService.GetAll())
			{
				yield return jeu.ToBLL();  
			}
		}

		public Jeux GetById(Guid id)
		{
			return _dalService.GetById(id)?.ToBLL();
		}

		public Guid Insert(Jeux jeu)
		{
			return _dalService.Insert(jeu.ToDAL());
		}
	}
}
