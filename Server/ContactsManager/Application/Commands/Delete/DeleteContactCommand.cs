namespace Application.Commands.Delete
{
	using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
	using Domain;
	using MediatR;

    public class DeleteContactCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result>
        {
            private readonly IContactsManagerDomainRepository _contactsManagerDomainRepository;

            public DeleteContactCommandHandler(
                IContactsManagerDomainRepository contactsManagerDomainRepository)
            {
                this._contactsManagerDomainRepository = contactsManagerDomainRepository;
            }

            public async Task<Result> Handle(
                DeleteContactCommand request,
                CancellationToken cancellationToken)
            {
                var contactExists = await this._contactsManagerDomainRepository.Exists(request.Id, cancellationToken);

                if (!contactExists)
                {
                    return contactExists;
                }

                return await this._contactsManagerDomainRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
