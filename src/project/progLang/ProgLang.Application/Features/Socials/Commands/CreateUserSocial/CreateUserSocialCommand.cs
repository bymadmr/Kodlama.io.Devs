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

namespace ProgLang.Application.Features.Socials.Commands.CreateUserSocial
{
    public class CreateUserSocialCommand:IRequest<CreatedUserSocialDto>
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }
        public string Url { get; set; }

        public class CreateUserSocialCommandHandler : IRequestHandler<CreateUserSocialCommand, CreatedUserSocialDto>
        {
            private readonly IUserSocialRepository _userSocialRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialBusinessRules _userSocialBusinessRules;
            public CreateUserSocialCommandHandler(UserSocialBusinessRules userSocialBusinessRules, IMapper mapper, IUserSocialRepository userSocialRepository)
            {
                _mapper = mapper;
                _userSocialBusinessRules = userSocialBusinessRules;
                _userSocialRepository = userSocialRepository;
            }
            public async Task<CreatedUserSocialDto> Handle(CreateUserSocialCommand request, CancellationToken cancellationToken)
            {
                await _userSocialBusinessRules.UserSocialCanNotBeDublicatedWhenInserted(request.UserId,request.SocialId);

                UserSocial mappedUserSocial = _mapper.Map<UserSocial>(request);
                UserSocial createdUserSocial = await _userSocialRepository.AddAsync(mappedUserSocial);
                CreatedUserSocialDto mappedCreatedUserSocialDto = _mapper.Map<CreatedUserSocialDto>(createdUserSocial);
                return mappedCreatedUserSocialDto;
            }
        }
    }
}
