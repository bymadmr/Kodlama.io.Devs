using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using ProgLang.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Socials.Rules
{
    public class UserSocialBusinessRules
    {
        private readonly IUserSocialRepository _userSocialRepository;
        public UserSocialBusinessRules(IUserSocialRepository userSocialRepository)
        {
            _userSocialRepository = userSocialRepository;
        }
        public void UserSocialShouldExistWhenRequested(UserSocial userSocial)
        {
            if (userSocial == null) throw new BusinessException("Requested user social does not exists");
        }
        public async Task UserSocialCanNotBeDublicatedWhenInserted(int userId,int socialId)
        {
            IPaginate<UserSocial> result = await _userSocialRepository.GetListAsync(t => t.UserId == userId&&t.SocialId==socialId);
            if (result.Items.Any()) throw new BusinessException("User Social exists");
        }
    }
}
