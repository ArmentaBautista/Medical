using System.Text.RegularExpressions;

namespace Medical.Domain.CommonRecords
{
    public record PhoneNumber
    {
        private static readonly Regex PhoneNumberRegex = new(@"^\+?[1-9]\d{1,14}$", RegexOptions.Compiled);

        public PhoneNumber(string Value)
        {
            if (!PhoneNumberRegex.IsMatch(Value))
            {
                throw new ArgumentException("Invalid phone number format.", nameof(Value));
            }
        }

        private PhoneNumber()
        {
            
        }
    }
}
