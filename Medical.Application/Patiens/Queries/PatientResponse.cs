namespace Medical.Application.Patiens.Queries;

public record PatientResponse(
    Guid Id,
    string Name,
    string Email,
    string PhoneNumber);