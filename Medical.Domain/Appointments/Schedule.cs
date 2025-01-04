using Medical.Domain.Abstractions;
using Medical.Domain.Doctors;

namespace Medical.Domain.Appointments
{
    public class Schedule : Entity
    {

        public Guid DoctorId { get; set; }
        public required Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
