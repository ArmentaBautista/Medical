using Medical.Application.Abstractions.CQRS;
using Medical.Application.Doctors.SearchDoctors;

namespace Medical.Application.Doctors.SearchDoctors
{  
    public sealed record GetDoctorQuery(Guid DoctorId)
        : IQuery<DoctorResponse>;
}
