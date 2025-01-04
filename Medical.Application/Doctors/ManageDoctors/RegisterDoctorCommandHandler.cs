using Medical.Application.Abstractions.CQRS;
using Medical.Application.Abstractions.Time;
using Medical.Application.Exceptions;
using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;
using Medical.Domain.CommonRecords;
using Medical.Domain.Doctors;
using Medical.Domain.CommonRecords;

namespace Medical.Application.Doctors.ManageDoctors
{
    internal sealed class RegisterDoctorCommandHandler 
        : ICommandHandler<RegisterDoctorCommand, Guid>
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public RegisterDoctorCommandHandler(
            IDoctorRepository doctorRepository,
            IUnitOfWork unitOfWork)
        {
            this.doctorRepository = doctorRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            RegisterDoctorCommand request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var doctor = Doctor.Register(
                    request.Id,
                    new Name(request.Name),
                    new LicenseNumber(request.LicenseNumber),
                    new Specialty(){Name = request.Specialty.Name });

                doctorRepository.Add(doctor);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return doctor.Id;
            }
            catch (PersistenceConcurrencyException)
            {
                return Result.Failure<Guid>(DoctorErrors.NotFound);
            }
        }
    }
}
