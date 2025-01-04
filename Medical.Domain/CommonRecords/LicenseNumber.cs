using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Medical.Domain.CommonRecords
{
    public record LicenseNumber
    {

        private static readonly Regex LicenseNumberRegex = new(@"^\+?[1-9]\d{1,14}$", RegexOptions.Compiled);

        public LicenseNumber(string Value)
        {
            if (!LicenseNumberRegex.IsMatch(Value))
            {
                throw new ArgumentException("LicenseNumber can only contain letters and numbers.", nameof(Value));
            }
        }

        private LicenseNumber()
        {
            
        }
    }
}
