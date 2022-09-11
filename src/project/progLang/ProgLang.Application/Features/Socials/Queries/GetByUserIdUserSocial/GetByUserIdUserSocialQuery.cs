using AutoMapper;
using Core.Security.Entities;
using MediatR;
using ProgLang.Application.Features.Socials.Dtos;
using ProgLang.Application.Features.Socials.Rules;
using ProgLang.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Socials.Queries.GetByUserIdUserSocial
{
    public class GetByUserIdUserSocialQuery : IRequest<UserSocialGetByUserIdDto>
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }

        public class GetByUserIdUserSocialQueryHandler : IRequestHandler<GetByUserIdUserSocialQuery, UserSocialGetByUserIdDto>
        {
            private readonly IUserSocialRepository _userSocialRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialBusinessRules _userSocialBusinessRules;
            public GetByUserIdUserSocialQueryHandler(UserSocialBusinessRules userSocialBusinessRules, IMapper mapper, IUserSocialRepository userSocialRepository)
            {
                _mapper = mapper;
                _userSocialBusinessRules = userSocialBusinessRules;
                _userSocialRepository = userSocialRepository;
            }
            public async Task<UserSocialGetByUserIdDto> Handle(GetByUserIdUserSocialQuery request, CancellationToken cancellationToken)
            {
                UserSocial mappedUserSocial = await _userSocialRepository.GetAsync(x => x.UserId == request.UserId && x.SocialId == request.SocialId);
                _userSocialBusinessRules.UserSocialShouldExistWhenRequested(mappedUserSocial);
                UserSocialGetByUserIdDto mappedUserSocialGetByUserIdDto = _mapper.Map<UserSocialGetByUserIdDto>(mappedUserSocial);
                return mappedUserSocialGetByUserIdDto;
            }
        }
    }
}
