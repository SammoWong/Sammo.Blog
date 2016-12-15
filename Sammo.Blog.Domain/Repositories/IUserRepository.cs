using Sammo.Blog.Domain.Entities;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsUserNameExistsAsync(string userName);

        Task<bool> IsEmailExistAsync(string email);
    }
}
