using MediatR;
using Medical.Application.Abstractions.Communication;
using Medical.Domain.Appointments;
using Medical.Domain.Appointments.Events;
using Medical.Domain.Patients;


namespace Medical.Application.Appointments.ReserveAppointment
{
    internal sealed class DoctorRegisterDomainEventHandler : INotificationHandler<AppointmentRejectedDomainEvent>
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IEmailService emailService;

        public DoctorRegisterDomainEventHandler(
            IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IEmailService emailService)
        {
            this.appointmentRepository = appointmentRepository;
            this.patientRepository = patientRepository;
            this.emailService = emailService;
        }

        public async Task Handle(AppointmentRejectedDomainEvent notification, CancellationToken cancellationToken)
        {
            var appointment = await appointmentRepository
                .GetByIdAsync(notification.AppointmentId, cancellationToken);

            if (appointment is null)
                return;

            var patient = await patientRepository.GetByIdAsync(appointment.PatientId, cancellationToken);

            if (patient is null)
                return;

            if (patient.Email != null)
                await emailService.SendAsync(
                    patient.Email,
                    "The Appointment has been reserved",
                    "Please, arrive to the Hospital 30 minutes before your date, and report with the Secretary");
        }
    }
}
