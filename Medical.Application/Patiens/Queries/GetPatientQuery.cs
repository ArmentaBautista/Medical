using Medical.Application.Abstractions.CQRS;
using Medical.Domain.Patients;

namespace Medical.Application.Patiens.Queries;

public record GetPatientQuery(Guid id):IQuery<PatientResponse>;