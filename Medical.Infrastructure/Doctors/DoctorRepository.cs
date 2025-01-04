using Medical.Domain.Doctors;
using Medical.Infrastructure.Shared;

namespace Medical.Infrastructure.Doctors
{
    internal sealed class DoctorRepository(ApplicationDbContext context)
        : RepositoryBase<Doctor>(context), IDoctorRepository
    {
        public Task<IEnumerable<Doctor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
