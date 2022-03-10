namespace Domain.Factories
{
	using Domain.Factories.Common;
	using Domain.Models;
	using System;

    public interface IContactFactory : IFactory<Contact>
    {
        IContactFactory WithFirstName(string firstName);

        IContactFactory WithSurName(string surName);

        IContactFactory WithAddress(string address);

        IContactFactory WithDateOfBirth(DateTime dateOfBirth);

        IContactFactory WithPhoneNumber(string phoneNumber);

        IContactFactory WithIBAN(string iban);
    }
}
