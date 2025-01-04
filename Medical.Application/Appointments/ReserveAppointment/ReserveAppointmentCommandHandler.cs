using Medical.Application.Abstractions.CQRS;
using Medical.Application.Abstractions.Time;
using Medical.Application.Exceptions;
using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;
using Medical.Domain.Doctors;
using Medical.Domain.Patients;

namespace Medical.Application.Appointments.ReserveAppointment
{
    internal sealed class RegisterDoctorCommandHandler : ICommandHandler<RegisterDoctorCommand, Guid>
    {
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly PricingService pricingService;
        private readonly ITimeProvider timeProvider;

        public RegisterDoctorCommandHandler(
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork,
            PricingService pricingService,
            ITimeProvider timeProvider)
        {
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
            this.appointmentRepository = appointmentRepository;
            this.unitOfWork = unitOfWork;
            this.pricingService = pricingService;
            this.timeProvider = timeProvider;
        }

        public async Task<Result<Guid>> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
        {
            var patient = await patientRepository.GetByIdAsync(request.PatientId, cancellationToken);

            if (patient is null)
                return Result.Failure<Guid>(PatientErrors.NotFound);

            var doctor = await doctorRepository.GetByIdAsync(request.DoctorId, cancellationToken);

            if (doctor is null)
                return Result.Failure<Guid>(DoctorErrors.NotFound);

            //TODO No es necesario ir a la base de datos para obtener el doctor y el paciente, se puede hacer una validación en memoria
            try
            {
                var appointment = Appointment.Reserve(
                    doctor.Id,
                    patient.Id,
                    request.AppointmentDate,
                    request.Price,
                    pricingService);

                appointmentRepository.Add(appointment);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return appointment.Id;
            }
            catch (PersistenceConcurrencyException)
            {
                return Result.Failure<Guid>(AppointmentErrors.NotFound);
            }
        }
    }
}
