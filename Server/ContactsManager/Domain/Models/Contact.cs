namespace Domain.Models
{
    using Domain.Exceptions;
    using Domain.Validation;
    using System;
    using static Domain.Models.ModelConstants.Contact;

    public class Contact : Entity<int>, IAggregateRoot
    {
        internal Contact(string firstName, string surName, string address, DateTime dateOfBirth, string phoneNumber, string IBAN)
        {
            this.Validate(firstName, surName, address, phoneNumber, IBAN);

            this.FirstName = firstName;
            this.SurName = surName;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.PhoneNumber = phoneNumber;
            this.IBAN = IBAN;
        }

        public string FirstName { get; private set; }

        public string SurName { get; private set; }

        public string Address { get; private set; }

		public DateTime DateOfBirth { get; private set; }

        public string PhoneNumber { get; private set; }

        public string IBAN { get; private set; }

        public Contact ChangeName(string name)
        {
            this.ValidateFirstName(name);
            this.FirstName = name;

            return this;
        }

        public Contact ChangeSurName(string summary)
        {
            this.ValidateSurName(summary);
            this.SurName = summary;

            return this;
        }

        public Contact ChangeAddress(string address)
        {
            this.ValidateSurName(address);
            this.Address = address;

            return this;
        }

        public Contact ChangeDateOfBIrth(DateTime dateOfBirth)
        {
            this.DateOfBirth = dateOfBirth;

            return this;
        }

        private void Validate(string firstName, string surName, string address, string phoneNumber, string iban)
        {
            this.ValidateFirstName(firstName);
            this.ValidateSurName(surName);
            this.ValidateAddress(address);
            this.ValidatePhoneNumber(phoneNumber);
            this.ValidateIBAN(iban);
        }

        private void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidContactException>(
                firstName,
                MinFirstNameLength,
                MaxFirstNameLength,
                nameof(this.FirstName));

        private void ValidateSurName(string surName)
            => Guard.ForStringLength<InvalidContactException>(
                surName,
                MinSurNameLength,
                MaxSurNameLength,
                nameof(this.SurName));

        private void ValidateAddress(string address)
            => Guard.ForStringLength<InvalidContactException>(
                address,
                MinAddressNameLength,
                MaxAddressNameLength,
                nameof(this.Address));

        private void ValidatePhoneNumber(string phoneNumber)
            => Guard.ForStringLength<InvalidContactException>(
                phoneNumber,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(this.PhoneNumber));

        private void ValidateIBAN(string iban)
            => Guard.ForRegex<InvalidContactException>(
                iban,
                IBANRegularExpression,
                nameof(this.IBAN));
    }
}
