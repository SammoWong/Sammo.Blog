using AutoMapper;
using Sammo.Blog.Application.Account.Dto;
using Sammo.Blog.Domain.DomainService.Interfaces;
using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using Sammo.Blog.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Sammo.Blog.Application.Account
{
    public class AccountAppService
    {
        private readonly IAccountService _service;
        private readonly IUserRepository _userRepository;
        public AccountAppService(IAccountService service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }
        public Task<Tuple<RegisterResult, User>> RegisterAsync(RegisterInput input)
        {
            Mapper.Initialize(m => m.CreateMap<RegisterInput, User>());
            var user = Mapper.Map<RegisterInput, User>(input);
            return _service.RegisterAsync(user);
        }

        public Task<Tuple<LoginResult, User>> LoginAsync(string userNameOrEmail, string password)
        {
            return _service.LoginAsync(userNameOrEmail, password);
        }

        public async Task<bool> ConfirmAsync(string userId)
        {
            Guid guid = new Guid(userId);
            return await _userRepository.FindSingleAsync(u => u.Id == guid && u.CreatedOn.AddHours(1) < DateTime.Now) != null;
        }
    }
}
