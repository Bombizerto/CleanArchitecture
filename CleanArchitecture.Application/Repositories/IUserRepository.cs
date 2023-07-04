using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Application.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?>GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
