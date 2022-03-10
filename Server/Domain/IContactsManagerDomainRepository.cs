namespace Domain
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Threading;
	using Domain.Models;

	public interface IContactsManagerDomainRepository : IDomainRepository<Contact>
	{
		Task<Contact> GetById(int id, CancellationToken cancellationToken = default);

		Task<bool> Exists(int id, CancellationToken cancellationToken = default);

		Task<bool> Delete(int id, CancellationToken cancellationToken = default);
	}
}
