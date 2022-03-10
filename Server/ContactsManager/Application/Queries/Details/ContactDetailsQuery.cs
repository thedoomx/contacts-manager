namespace Application.Queries.Details
{
	using System.Threading;
    using System.Threading.Tasks;
	using Application.Common;
	using Application.Queries.Common;
	using MediatR;

    public class ContactDetailsQuery : EntityCommand<int>, IRequest<ContactOutputModel>
    {
        public class ContactDetailsQueryHandler : IRequestHandler<ContactDetailsQuery, ContactOutputModel>
        {
            private readonly IContactsManagerQueryRepository _contactsManagerQueryRepository;

            public ContactDetailsQueryHandler(
                IContactsManagerQueryRepository contactsManagerQueryRepository)
            {
                this._contactsManagerQueryRepository = contactsManagerQueryRepository;
            }

            public async Task<ContactOutputModel> Handle(
                ContactDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var contactDetails = await this._contactsManagerQueryRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                return contactDetails;
            }
        }
    }
}
