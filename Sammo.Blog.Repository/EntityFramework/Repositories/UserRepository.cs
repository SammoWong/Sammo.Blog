using Sammo.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sammo.Blog.Domain;
using System.Data.Entity;
using Sammo.Blog.Domain.Repositories;
using Sammo.Blog.Domain.Enums;

namespace Sammo.Blog.Repository.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ISammoDbContext sammoDbContext) : base(sammoDbContext)
        {

        }
        public Task<bool> IsUserNameExistsAsync(string userName)
        {
            return IsExistsAsync(u => u.UserName == userName);
        }

        public Task<bool> IsEmailExistAsync(string email)
        {
            return IsExistsAsync(u => u.Email == email);
        }
    }
}
