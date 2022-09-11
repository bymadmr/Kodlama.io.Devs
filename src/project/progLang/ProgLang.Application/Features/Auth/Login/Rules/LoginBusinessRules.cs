using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Login.Rules
{
    public class LoginBusinessRules
    {
        public void UserShouldExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("Requested user does not exists");
        }
        public void VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt)) throw new BusinessException("The password is incorrect");
        }
    }
}
