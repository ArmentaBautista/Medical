using Medical.Domain.Abstractions;
using Medical.Domain.Appointments.Events;
using Medical.Domain.Doctors;
using Medical.Domain.Patients;

namespace Medical.Domain.Appointments
{
    public class Appointment : Entity
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }

        public static Appointment Reserve(
            Guid doctorId,
            Guid patientId, 
            DateTime appointmentDate,
            decimal price,
            PricingService pricingService)
        {
            var priceWithTax = pricingService.CalculatePriceWithTax(price);
            
            var appointment = new Appointment()
            {
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentDate = appointmentDate,
                Status = AppointmentStatus.Reserved
            };

            appointment.RaiseDomainEvent(new AppointmentReservedDomainEvent(appointment.Id));
            return appointment;
        }

        public Result Confirm()
        {
            if (Status != AppointmentStatus.Reserved)
            {
                return Result.Failure(AppointmentErrors.NotFound);
            }

            Status = AppointmentStatus.Reserved;
            RaiseDomainEvent(new AppointmentConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Cancel()
        {
            if (Status != AppointmentStatus.Reserved)
            {
                return Result.Failure(AppointmentErrors.NotFound);
            }

            Status = AppointmentStatus.Cancelled;
            RaiseDomainEvent(new AppointmentRejectedDomainEvent(Id));

            return Result.Success();
        }

        public Result Complete()
        {
            if (Status != AppointmentStatus.Reserved)
            {
                return Result.Failure(AppointmentErrors.NotFound);
            }

            Status = AppointmentStatus.Reserved;
            
            RaiseDomainEvent(new AppointmentCompletedDomainEvent(Id));

            return Result.Success();
        }

        public Result Rescheduled(DateTime newDate)
        {
            if (Status != AppointmentStatus.Reserved)
            {
                return Result.Failure(AppointmentErrors.NotFound);
            }

            Status = AppointmentStatus.Rescheduled;
            
            RaiseDomainEvent(new AppointmentConfirmedDomainEvent(Id));

            return Result.Success();
        }

        private Appointment()
        {

        }

    }
}
