using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;

namespace Medical.Domain.Patients
{
    public class Prescription : Entity
    {
        public Prescription(string instructions)
        {
            Instructions = instructions;
        }

        public int AppointmentId { get; set; }
        public required Appointment Appointment { get; set; }
        public required string Medication { get; set; }
        public string Instructions { get; set; }
    }
}
