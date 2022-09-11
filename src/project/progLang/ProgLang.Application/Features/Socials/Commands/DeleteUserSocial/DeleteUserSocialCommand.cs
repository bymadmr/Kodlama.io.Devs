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

namespace ProgLang.Application.Features.Socials.Commands.DeleteUserSocial
{
    public class DeleteUserSocialCommand : IRequest<DeletedUserSocialDto>
    {
        public int UserId { get; set; }
        public int SocialId { get; set; }

        public class DeleteUserSocialCommandHandler : IRequestHandler<DeleteUserSocialCommand, DeletedUserSocialDto>
        {
            private readonly IUserSocialRepository _userSocialRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialBusinessRules _userSocialBusinessRules;
            public DeleteUserSocialCommandHandler(IMapper mapper, IUserSocialRepository userSocialRepository, UserSocialBusinessRules userSocialBusinessRules)
            {
                _mapper = mapper;
                _userSocialRepository = userSocialRepository;
                _userSocialBusinessRules = userSocialBusinessRules;
            }
            public async Task<DeletedUserSocialDto> Handle(DeleteUserSocialCommand request, CancellationToken cancellationToken)
            {
                UserSocial? mappedUserSocial = await _userSocialRepository.GetAsync(x => x.UserId == request.UserId && x.SocialId == request.SocialId);
                _userSocialBusinessRules.UserSocialShouldExistWhenRequested(mappedUserSocial);
                
                UserSocial deletedUserSocial = await _userSocialRepository.DeleteAsync(mappedUserSocial);
                DeletedUserSocialDto mappedDeletedUserSocialDto = _mapper.Map<DeletedUserSocialDto>(deletedUserSocial);
                return mappedDeletedUserSocialDto;
            }
        }
    }
}
