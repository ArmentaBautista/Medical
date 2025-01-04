using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Medical.Domain.Patients
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default);
        Task Update(Patient patient);
        Task Delete(Guid id);
    }
}
