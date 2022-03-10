namespace Application.Commands.Create
{
	using Application.Commands.Common;
	using Domain;
	using Domain.Factories;
	using MediatR;
	using System.Threading;
	using System.Threading.Tasks;

	public class CreateContactCommand : ContactCommand<CreateContactCommand>, IRequest<CreateContactOutputModel>
	{
		public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactOutputModel>
		{
			private readonly IContactsManagerDomainRepository _contactsManagerDomainRepository;
			private readonly IContactFactory _contactFactory;

			public CreateContactCommandHandler(
				IContactsManagerDomainRepository contactsManagerDomainRepository,
				IContactFactory contactFactory)
			{
				this._contactsManagerDomainRepository = contactsManagerDomainRepository;
				this._contactFactory = contactFactory;
			}

			public async Task<CreateContactOutputModel> Handle(
				CreateContactCommand request,
				CancellationToken cancellationToken)
			{
				var contact = this._contactFactory
					.WithFirstName(request.FirstName)
					.WithSurName(request.SurName)
					.WithAddress(request.Address)
					.WithDateOfBirth(request.DateOfBirth)
					.WithPhoneNumber(request.PhoneNumber)
					.WithIBAN(request.IBAN)
					.Build();

				await this._contactsManagerDomainRepository.Save(contact, cancellationToken);

				return new CreateContactOutputModel(contact.Id);
			}
		}
	}
}
