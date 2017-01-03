using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.DomainService.Interfaces
{
    public interface IAccountService
    {
        Task<Tuple<RegisterResult, User>> RegisterAsync(User user);

        Task<Tuple<LoginResult, User>> LoginAsync(string userNameOrEmail, string password);
    }
}
