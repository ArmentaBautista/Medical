using Medical.Domain.Abstractions;
using Medical.Domain.CommonRecords;

namespace Medical.Domain.Patients
{
    public class Patient : Entity   
    {
        public required Name Name { get; set; }
        public required Email Email { get; set; }
        public required PhoneNumber PhoneNumber { get; set; }

        private Patient()
        {
            
        }
    }
}
