using FluentValidation;

namespace Medical.Application.Doctors.ManageDoctors
{
    public class RegisterDoctorCommandValidator : AbstractValidator<RegisterDoctorCommand>
    {
        public RegisterDoctorCommandValidator()
        {
            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.LicenseNumber).NotEmpty();
            //RuleFor(x => x.Specialty).NotEmpty()
            //    .WithMessage("All data are required");
        }
    }
}
