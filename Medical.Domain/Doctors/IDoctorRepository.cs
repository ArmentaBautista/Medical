using Medical.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical.Domain.Doctors
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Guid id);
        void Add(Doctor doctor);
    }
}
