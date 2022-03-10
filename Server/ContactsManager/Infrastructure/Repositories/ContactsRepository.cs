namespace Infrastructure.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using Domain.Models;
	using Infrastructure.Persistence;
	using Application;
	using Domain;

	internal class ContactsRepository : DataRepository<IContactsManagerDbContext, Contact>,
		IContactsManagerDomainRepository,
		IContactsManagerQueryRepository
	{
		private readonly IMapper mapper;

		public ContactsRepository(IContactsManagerDbContext db, IMapper mapper)
			: base(db)
			=> this.mapper = mapper;

		
		public async Task<Contact> GetById(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
