using Sammo.Blog.Domain.Entities;
using System.Threading.Tasks;
using Sammo.Blog.Domain.Repositories;

namespace Sammo.Blog.Repository.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SammoDbContext sammoDbContext) : base(sammoDbContext)
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
