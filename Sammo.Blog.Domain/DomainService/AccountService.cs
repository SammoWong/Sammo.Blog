using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.DomainService.Interfaces;
using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using Sammo.Blog.Domain.Repositories;
using Sammo.Blog.Infrastructure;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.DomainService
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterResult> RegisterAsync(User user)
        {
            if (await _userRepository.IsExistsAsync(u => u.UserName == user.UserName))
                return RegisterResult.UserNameExists;

            if (await _userRepository.IsExistsAsync(u => u.Email == user.Email))
                return RegisterResult.EmailExists;

            var salt = StringUtil.CreateSalt(SammoConstants.Validation.SaltSize);
            var password = StringUtil.GenerateSaltedHash(user.Password, salt);
            user.Salt = salt;
            user.Password = password;
            await _userRepository.AddAsync(user);
            return RegisterResult.Success;
        }

        public async Task<LoginResult> LoginAsync(string userNameOrEmail, string password)
        {
            var user = new User();
            if (userNameOrEmail.Contains("@"))
            {
                user = await _userRepository.FindSingleAsync(u => u.Email == userNameOrEmail);
            }
            else
            {
                user = await _userRepository.FindSingleAsync(u => u.UserName == userNameOrEmail);
            }
            if (user == null)
                return LoginResult.UserNameOrEmailNotFound;

            var salt = user.Salt;
            password = StringUtil.GenerateSaltedHash(password, salt);
            if (password != user.Password)
                return LoginResult.UserNameOrEmailNotFound;

            return LoginResult.Success;
        }
    }
}
