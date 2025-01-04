using FluentValidation;

namespace Medical.Application.Appointments.ReserveAppointment
{
    public class RegisterDoctorCommandValidator : AbstractValidator<RegisterDoctorCommand>
    {
        public RegisterDoctorCommandValidator()
        {
            RuleFor(x => x.DoctorId).NotEmpty();
            RuleFor(x => x.PatientId).NotEmpty();
            RuleFor(x => x.AppointmentDate).GreaterThan(x => DateTime.Today)
                .WithMessage("The Appointment date must be after today");
        }
    }
}
