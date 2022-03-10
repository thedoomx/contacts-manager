namespace Application.Commands.Common
{
	using System;
	using Application.Common;
	using FluentValidation;
	using static Domain.Models.ModelConstants.Contact;

	public class ContactCommandValidator<TCommand> : AbstractValidator<ContactCommand<TCommand>>
		where TCommand : EntityCommand<int>
	{
		public ContactCommandValidator()
		{
			this.RuleFor(c => c.FirstName)
				.MinimumLength(MinFirstNameLength)
				.MaximumLength(MaxFirstNameLength)
				.NotEmpty();

			this.RuleFor(c => c.SurName)
				.MinimumLength(MinSurNameLength)
				.MaximumLength(MaxSurNameLength)
				.NotEmpty();

			this.RuleFor(c => c.Address)
				.MinimumLength(MinAddressNameLength)
				.MaximumLength(MaxAddressNameLength)
				.NotEmpty();

			this.RuleFor(c => c.DateOfBirth)
				.NotEmpty();

			this.RuleFor(c => c.PhoneNumber)
				.MinimumLength(MinPhoneNumberLength)
				.MaximumLength(MaxPhoneNumberLength)
				.NotEmpty();

			this.RuleFor(c => c.IBAN)
				.Matches(IBANRegularExpression)
				.NotEmpty();
		}
	}
}
