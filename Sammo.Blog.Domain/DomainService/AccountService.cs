using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.DomainService.Interfaces;
using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using Sammo.Blog.Domain.Repositories;
using Sammo.Blog.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.DomainService
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AccountService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Tuple<RegisterResult, User>> RegisterAsync(User user)
        {
            if (await _userRepository.IsExistsAsync(u => u.UserName == user.UserName))
                return new Tuple<RegisterResult, User>(RegisterResult.UserNameExists, null);

            if (await _userRepository.IsExistsAsync(u => u.Email == user.Email))
                return new Tuple<RegisterResult, User>(RegisterResult.EmailExists, null);

            var salt = StringUtil.CreateSalt(SammoConstants.Validation.SaltSize);
            var password = StringUtil.GenerateSaltedHash(user.Password, salt);
            user.Salt = salt;
            user.Password = password;
            user.Role = await _roleRepository.FindSingleAsync(r => r.Type == SammoConstants.Roles.User);
            await _userRepository.AddAsync(user);
            return new Tuple<RegisterResult, User>(RegisterResult.Success, user);
        }

        public async Task<Tuple<LoginResult, User>> LoginAsync(string userNameOrEmail, string password)
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
                return new Tuple<LoginResult, User>(LoginResult.UserNameOrEmailNotFound, null);

            var salt = user.Salt;
            password = StringUtil.GenerateSaltedHash(password, salt);
            if (password != user.Password)
                return new Tuple<LoginResult, User>(LoginResult.PasswordIncorrect, null);

            if (user.IsLocked)
                return new Tuple<LoginResult, User>(LoginResult.IsLocked, null);

            return new Tuple<LoginResult, User>(LoginResult.Success, user);
        }
    }
}
