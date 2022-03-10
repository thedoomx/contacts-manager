namespace Domain.Models
{
    public static class ModelConstants
    {
        public class Contact
        {
            public const int MinFirstNameLength = 2;
            public const int MaxFirstNameLength = 30;

            public const int MinSurNameLength = 2;
            public const int MaxSurNameLength = 30;

            public const int MinAddressNameLength = 5;
            public const int MaxAddressNameLength = 100;

            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;

            public const string IBANRegularExpression = @"^[A-Z]{2}(?:[ ]?[0-9]){18,20}$";
        }
    }
}
