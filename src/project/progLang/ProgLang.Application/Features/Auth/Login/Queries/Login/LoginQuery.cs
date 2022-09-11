using AutoMapper;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Security.Entities;
using MediatR;
using ProgLang.Application.Features.Auth.Login.Dtos;
using ProgLang.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgLang.Application.Features.Auth.Login.Rules;

namespace ProgLang.Application.Features.Auth.Login.Queries.Login
{
    public class LoginQuery : IRequest<LoginAccessTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AuthenticatorCode { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginAccessTokenDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly LoginBusinessRules _loginBusinessRules;
            public LoginQueryHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, LoginBusinessRules loginBusinessRules, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _loginBusinessRules = loginBusinessRules;
                _operationClaimRepository = operationClaimRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
            }
            public async Task<LoginAccessTokenDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                User? userToCheck = await _userRepository.GetAsync(x => x.Email == request.Email);
                _loginBusinessRules.UserShouldExistWhenRequested(userToCheck);
                _loginBusinessRules.VerifyPassword(request.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt);
                List<int> oclist = _userOperationClaimRepository.GetList(x => x.UserId == userToCheck.Id).Items.Select(x => x.OperationClaimId).ToList();
                List<OperationClaim> useroperationClaims = _operationClaimRepository.GetList().Items.Where(x=> oclist.Contains(x.Id)).ToList();
                AccessToken createdAccessToken = _tokenHelper.CreateToken(userToCheck, useroperationClaims);
                LoginAccessTokenDto mappedAccessTokenDto = _mapper.Map<LoginAccessTokenDto>(createdAccessToken);
                return mappedAccessTokenDto;
            }

        }
    }
}
