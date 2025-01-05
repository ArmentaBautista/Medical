using Medical.Application.Abstractions.CQRS;
using Medical.Domain.Abstractions;
using Medical.Domain.Patients;

namespace Medical.Application.Patiens.Queries;

public class GetPatientQueryHandler:IQueryHandler<GetPatientQuery,PatientResponse>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientResponse>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var result = await _patientRepository.GetByIdAsync(request.id, cancellationToken);

        if (result == null)
            return Result.Failure<PatientResponse>(PatientErrors.NotFound);

        return new PatientResponse(result.Id, result.Name.ToString(),result.Email.ToString(), result.PhoneNumber.ToString());

    }
}