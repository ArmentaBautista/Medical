using Medical.Application.Abstractions.CQRS;

namespace Medical.Application.Patiens.Commands;

public record RegisterPatientCommand(
    string Name,
    string Email,
    string PhoneNumber):ICommand<Guid>;