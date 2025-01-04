using Medical.Domain.Users;
using Medical.Infrastructure.Shared;

namespace Medical.Infrastructure.Users
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
