using BLL.Mappers;
using B = BLL.Entities;
using Common.Repositories;
using D = DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
	/// Service pour la gestion des utilisateurs, faisant le lien entre la BLL et la DAL.  

	public class TagService : ITagRepository<B.Tag>
	
	{
		// Référence au dépôt d'accès aux données des tags (DAL).
		private readonly ITagRepository<D.Tag> _tagRepository;

		// Constructeur qui injecte le dépôt d'utilisateurs (DAL) pour gérer l'accès aux données (facilite modularité (remplacement implémentation) + test unitaire).
		public TagService(ITagRepository<D.Tag> tagRepository)
		{
			_tagRepository = tagRepository;
		}


		public int Insert(string nom)
		{

			return _tagRepository.Insert(nom); 
		}

		public List<B.Tag> GetAll()
		{
			List<B.Tag> tags = new List<B.Tag>();

			foreach (D.Tag tag in _tagRepository.GetAll())
			{
				tags.Add(tag.ToBLL()); 
			}

			return tags;
		}
	}
}