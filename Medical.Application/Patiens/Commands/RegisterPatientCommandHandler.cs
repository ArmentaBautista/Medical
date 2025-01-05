using Medical.Application.Abstractions.CQRS;
using Medical.Application.Exceptions;
using Medical.Domain.Abstractions;
using Medical.Domain.Patients;

namespace Medical.Application.Patiens.Commands;

public class RegisterPatientCommandHandler:ICommandHandler<RegisterPatientCommand,Guid>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterPatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        this._patientRepository = patientRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterPatientCommand request, CancellationToken cancellationToken)
    {
        
        try
        {
            var patient = Patient.Register(request.Name, request.Email, request.PhoneNumber);
            _patientRepository.Add(patient);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return patient.Id;

        }
        catch (PersistenceConcurrencyException )
        {
            return Result.Failure<Guid>(PatientErrors.NotFound);
        }
    }
}