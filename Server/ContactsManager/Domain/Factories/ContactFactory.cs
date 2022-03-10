namespace Domain.Factories
{
	using Domain.Models;
	using System;

    internal class ContactFactory : IContactFactory
    {
        private string firstName = default!;
        private string surName = default!;
        private string address = default!;
        private DateTime dateOfBirth = default!;
        private string phoneNumber = default!;
        private string iban = default!;

        public IContactFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public IContactFactory WithSurName(string surName)
        {
            this.surName = surName;
            return this;
        }

        public IContactFactory WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public IContactFactory WithDateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public IContactFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public IContactFactory WithIBAN(string iban)
        {
            this.iban = iban;
            return this;
        }

        public Contact Build()
        {
            var contact = new Contact(
                this.firstName,
                this.surName,
                this.address,
                this.dateOfBirth,
                this.phoneNumber,
                this.iban);

            return contact;
        }
    }
}
