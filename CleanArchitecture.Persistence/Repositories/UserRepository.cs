using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var user = Context.Users.FirstOrDefaultAsync(x => x.Email == email && x.DateDeleted == null,cancellationToken);
            return user;
        }

    }
}
