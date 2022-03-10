namespace Application
{
	using Application.Queries.Common;
	using Domain.Models;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IContactsManagerQueryRepository : IQueryRepository<Contact>
	{
		Task<ContactOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

		Task<IEnumerable<ContactOutputModel>> Search(CancellationToken cancellationToken = default);
	}
}
