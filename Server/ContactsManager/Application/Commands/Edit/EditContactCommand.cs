namespace Application.Commands.Edit
{
	using Application.Commands.Common;
	using Application.Common;
	using Domain;
	using Domain.Factories;
	using MediatR;
	using System.Threading;
	using System.Threading.Tasks;

	public class EditContactCommand : ContactCommand<EditContactCommand>, IRequest<Result>
	{
		public class EditCarAdCommandHandler : IRequestHandler<EditContactCommand, Result>
		{
			private readonly IContactsManagerDomainRepository _contactsManagerDomainRepository;

			public EditCarAdCommandHandler(
			   IContactsManagerDomainRepository contactsManagerDomainRepository)
			{
				this._contactsManagerDomainRepository = contactsManagerDomainRepository;
			}

			public async Task<Result> Handle(
				EditContactCommand request,
				CancellationToken cancellationToken)
			{
				var contactExists = await this._contactsManagerDomainRepository.Exists(request.Id, cancellationToken);

				if (!contactExists)
				{
					return contactExists;
				}

				var contact = await this._contactsManagerDomainRepository
					.GetById(request.Id, cancellationToken);

				contact
					.UpdateFirstName(request.FirstName)
					.UpdateSurName(request.SurName)
					.UpdateAddress(request.Address)
					.UpdateDateOfBIrth(request.DateOfBirth)
					.UpdatePhoneNumber(request.PhoneNumber)
					.UpdateIBAN(request.IBAN);

				await this._contactsManagerDomainRepository.Save(contact, cancellationToken);

				return Result.Success;
			}
		}
	}
}
