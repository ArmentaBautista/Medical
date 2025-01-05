using System.Text.RegularExpressions;

namespace Medical.Domain.CommonRecords
{
    public record Email
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        public string Value { get; private set; }

        public Email(string value)
        {
            if (!EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("Invalid email format.", nameof(value));
            }

            Value = value;
        }

        private Email()
        {
            
        }

        
    }
}
