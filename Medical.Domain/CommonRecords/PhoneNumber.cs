using System.Text.RegularExpressions;

namespace Medical.Domain.CommonRecords
{
    public record PhoneNumber
    {
        private static readonly Regex PhoneNumberRegex = new(@"^\+?[1-9]\d{1,14}$", RegexOptions.Compiled);
        public string Value { get; private set; }

        public PhoneNumber(string value
        )
        {
            if (!PhoneNumberRegex.IsMatch(value))
            {
                throw new ArgumentException("Invalid phone number format.", nameof(value));
            }

            Value = value;
        }

        private PhoneNumber()
        {
            
        }
    }
}
