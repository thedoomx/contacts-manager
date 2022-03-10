namespace Application.Commands.Common
{
    using Application.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ContactCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string FirstName { get; set; } = default!;

        public string SurName { get; set; } = default!;

        public string Address { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string IBAN { get; set; } = default!;
    }
}
