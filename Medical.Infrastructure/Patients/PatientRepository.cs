using Medical.Domain.Patients;
using Medical.Infrastructure.Shared;

namespace Medical.Infrastructure.Patients
{
    internal sealed class PatientRepository(ApplicationDbContext context)
        : RepositoryBase<Patient>(context), IPatientRepository
    {

        public Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Update(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
