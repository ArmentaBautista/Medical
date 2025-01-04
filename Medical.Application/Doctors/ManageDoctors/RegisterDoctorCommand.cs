using Medical.Application.Abstractions.CQRS;
using Medical.Domain.Doctors;

namespace Medical.Application.Doctors.ManageDoctors
{
    public record RegisterDoctorCommand(
        Guid Id,
        string Name,
        string LicenseNumber,
        Specialty Specialty) : ICommand<Guid>;
}
