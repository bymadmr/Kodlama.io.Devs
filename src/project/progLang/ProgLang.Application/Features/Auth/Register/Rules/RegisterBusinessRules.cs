using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using ProgLang.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Register.Rules
{
    public class RegisterBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public RegisterBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task UserEMailCanNotBeDublicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(t => t.Email == email);
            if (result.Items.Any()) throw new BusinessException("User email exists");
        }
    }
}
