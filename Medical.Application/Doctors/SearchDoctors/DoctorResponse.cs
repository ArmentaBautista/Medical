using FlatFinder.Application.Flats.SearchFlats;
using Medical.Application.Doctors.SearchDoctors;
using Medical.Domain.Appointments;
using Medical.Domain.Doctors;

namespace Medical.Application.Doctors.SearchDoctors
{
    public sealed class DoctorResponse
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = default!;

        public string LicenseNumber { get; set; } = default!;

        public string Specialty { get; set; } = default!;

    }
}
