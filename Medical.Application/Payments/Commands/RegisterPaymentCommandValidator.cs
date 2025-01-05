using FluentValidation;

namespace Medical.Application.Payments.Commands;

public class RegisterPaymentCommandValidator:AbstractValidator<RegisterPaymentCommand>
{
    public RegisterPaymentCommandValidator()
    {
        RuleFor(x => x.AppointmentId);
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("The payment amount must be greater than 0.");
    }
}