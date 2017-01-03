using AutoMapper;
using Sammo.Blog.Application.Account.Dto;
using Sammo.Blog.Domain.DomainService.Interfaces;
using Sammo.Blog.Domain.Entities;
using Sammo.Blog.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Sammo.Blog.Application.Account
{
    public class AccountAppService
    {
        private readonly IAccountService _service;
        public AccountAppService(IAccountService service)
        {
            _service = service;
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
    }
}
