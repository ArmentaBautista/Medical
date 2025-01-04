using MediatR;
using Medical.Domain.Doctors;
using Medical.Domain.Doctors.Events;

namespace Medical.Application.Doctors.ManageDoctors
{
    internal sealed class DoctorRegisterDomainEventHandler : INotificationHandler<DoctorRegisterDomainEvent>
    {
        private readonly IDoctorRepository doctorRepository;
        
        public DoctorRegisterDomainEventHandler(
            IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task Handle(DoctorRegisterDomainEvent notification, CancellationToken cancellationToken)
        {
            var doctor = await doctorRepository
                .GetByIdAsync(notification.DoctorId, cancellationToken);

            if (doctor is null)
                return;

        }
    }
}
