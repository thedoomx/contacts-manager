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
	using System.Linq;
	using Application.Queries.Common;

	internal class ContactsRepository : DataRepository<IContactsManagerDbContext, Contact>,
		IContactsManagerDomainRepository,
		IContactsManagerQueryRepository
	{
		private readonly IMapper mapper;

		public ContactsRepository(IContactsManagerDbContext db, IMapper mapper)
			: base(db)
			=> this.mapper = mapper;

		
		public async Task<Contact> GetById(int id, CancellationToken cancellationToken)
		=> await this
				.All()
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		public async Task<bool> Exists(int id, CancellationToken cancellationToken = default)
			=> await this
				.All()
				.Where(x => x.Id == id)
				.AnyAsync(x => x.Id == id, cancellationToken);

		public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
		{
			var contact = await this.All().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

			if (contact == null)
			{
				return false;
			}

			this.Data.Contacts.Remove(contact);

			await this.Data.SaveChangesAsync(cancellationToken);

			return true;
		}

		public async Task<ContactOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
		=> await this.mapper
			   .ProjectTo<ContactOutputModel>(this
					.All())
			   .FirstOrDefaultAsync(cancellationToken);

		public async Task<IEnumerable<ContactOutputModel>> Search(CancellationToken cancellationToken = default)
		=> await this.mapper
			   .ProjectTo<ContactOutputModel>(this
					.All())
			   .ToListAsync(cancellationToken);
	}
}
