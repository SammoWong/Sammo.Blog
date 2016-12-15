using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.DomainService.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult> RegisterAsync(User user);

        Task<LoginResult> LoginAsync(string userNameOrEmail, string password);
    }
}
