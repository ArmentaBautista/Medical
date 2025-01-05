using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Medical.Domain.CommonRecords
{
    public record Name
    {
        public string CompleteName { get; set; } = string.Empty;

        private static readonly Regex NameRegex = new(@"^[a-zA-Z\s.]+$", RegexOptions.Compiled);
        
        public Name(string Value)
        {
            if (!NameRegex.IsMatch(Value))
            {
                throw new ArgumentException("Name can only contain letters.", nameof(Value));
            }
            CompleteName = Value.Trim();
        }

        public Name()
        {
        }
    }
}
