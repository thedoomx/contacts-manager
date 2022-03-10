namespace Application.Queries.Search
{
	using System.Collections.Generic;
	using System.Threading;
    using System.Threading.Tasks;
	using Application.Common;
	using Application.Queries.Common;
	using MediatR;

    public class ContactsSearchQuery : EntityCommand<int>, IRequest<IEnumerable<ContactOutputModel>>
    {
        public class ContactsSearchQueryHandler : IRequestHandler<ContactsSearchQuery, IEnumerable<ContactOutputModel>>
        {
            private readonly IContactsManagerQueryRepository _contactsManagerQueryRepository;

            public ContactsSearchQueryHandler(
                IContactsManagerQueryRepository contactsManagerQueryRepository)
            {
                this._contactsManagerQueryRepository = contactsManagerQueryRepository;
            }

            public async Task<IEnumerable<ContactOutputModel>> Handle(
                ContactsSearchQuery request,
                CancellationToken cancellationToken)
            {
                var contacts = await this._contactsManagerQueryRepository.Search(
                    cancellationToken);

                return contacts;
            }
        }
    }
}
