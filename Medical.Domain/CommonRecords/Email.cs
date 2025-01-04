using System.Text.RegularExpressions;

namespace Medical.Domain.CommonRecords
{
    public record Email
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public Email(string value)
        {
            if (!EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("Invalid email format.", nameof(value));
            }
        }

        private Email()
        {
            
        }
    }
}
