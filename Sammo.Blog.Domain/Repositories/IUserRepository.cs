using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsUserNameExistsAsync(string userName);

        Task<bool> IsEmailExistAsync(string email);
    }
}
