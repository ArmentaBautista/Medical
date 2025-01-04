using Medical.Domain.Abstractions;
using Medical.Domain.CommonRecords;
using Medical.Domain.Doctors.Events;

namespace Medical.Domain.Doctors
{
    public class Doctor : Entity
    {
        public required Name Name { get; set; }
        public required LicenseNumber LicenseNumber { get; set; }
        public required Specialty Specialty { get; set; }
        private Doctor()
        {
            
        }

        public static Doctor Register(
            Guid doctorId,
            Name name, 
            LicenseNumber licenseNumber, 
            Specialty specialty)
        {
            var doctor = new Doctor()
            {
                Id = doctorId,
                Name = name,
                LicenseNumber = licenseNumber,
                Specialty = specialty
            };

            doctor.RaiseDomainEvent(new DoctorRegisterDomainEvent(doctor.Id));
            return doctor;
        }

    }


    
}
