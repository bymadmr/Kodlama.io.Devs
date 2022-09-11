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

namespace ProgLang.Application.Features.Socials.Commands.UpdateUserSocial
{
    public class UpdateUserSocialCommand : IRequest<UpdatedUserSocialDto>
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }
        public string Url { get; set; }

        public class UpdateUserSocialCommandHandler : IRequestHandler<UpdateUserSocialCommand, UpdatedUserSocialDto>
        {
            private readonly IUserSocialRepository _userSocialRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialBusinessRules _userSocialBusinessRules;
            public UpdateUserSocialCommandHandler(IMapper mapper, IUserSocialRepository userSocialRepository, UserSocialBusinessRules userSocialBusinessRules)
            {
                _mapper = mapper;
                _userSocialRepository = userSocialRepository;
                _userSocialBusinessRules = userSocialBusinessRules;
            }
            public async Task<UpdatedUserSocialDto> Handle(UpdateUserSocialCommand request, CancellationToken cancellationToken)
            {
                UserSocial mappedUserSocial = await _userSocialRepository.GetAsync(x => x.UserId == request.UserId && x.SocialId == request.SocialId);
                _userSocialBusinessRules.UserSocialShouldExistWhenRequested(mappedUserSocial);
                mappedUserSocial.Url = request.Url;
                UserSocial updatedUserSocial = await _userSocialRepository.UpdateAsync(mappedUserSocial);
                UpdatedUserSocialDto mappedUpdatedUserSocialDto = _mapper.Map<UpdatedUserSocialDto>(updatedUserSocial);
                return mappedUpdatedUserSocialDto;
            }
        }
    }
}
