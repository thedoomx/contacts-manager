namespace Application.Queries.Common
{
	using System;

    public class ContactOutputModel
    {
        public ContactOutputModel()
        {
        }

        public int Id { get; private set; }

        public string FirstName { get; set; } = default!;

        public string SurName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string IBAN { get; set; } = default!;
    }
}
