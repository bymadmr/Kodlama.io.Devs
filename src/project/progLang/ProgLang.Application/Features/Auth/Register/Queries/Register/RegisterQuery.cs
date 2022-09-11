using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using ProgLang.Application.Features.Auth.Login.Dtos;
using ProgLang.Application.Features.Auth.Register.Dtos;
using ProgLang.Application.Features.Auth.Register.Rules;
using ProgLang.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Auth.Register.Queries.Register
{
    public class RegisterQuery:IRequest<RegisterAccessTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public class RegisterQueryHandler : IRequestHandler<RegisterQuery, RegisterAccessTokenDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly RegisterBusinessRules _registerBusinessRules;
            public RegisterQueryHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, RegisterBusinessRules registerBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _registerBusinessRules = registerBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
                _operationClaimRepository = operationClaimRepository;
            }
            public async Task<RegisterAccessTokenDto> Handle(RegisterQuery request, CancellationToken cancellationToken)
            {
                await _registerBusinessRules.UserEMailCanNotBeDublicatedWhenInserted(request.Email);
                byte[] passwordHash, paswordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out paswordSalt);
                User newUser = new User
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    AuthenticatorType = 0,
                    PasswordHash = passwordHash,
                    PasswordSalt = paswordSalt,
                    Status = true,
                };
                User createdUser = await _userRepository.AddAsync(newUser);
                List<OperationClaim> useroperationClaims = _userOperationClaimRepository.GetList(x => x.UserId == createdUser.Id).Items.Select(x=>x.OperationClaim).ToList();
                AccessToken createdAccessToken = _tokenHelper.CreateToken(createdUser, useroperationClaims);
                RegisterAccessTokenDto mappedAccessTokenDto = _mapper.Map<RegisterAccessTokenDto>(createdAccessToken);
                return mappedAccessTokenDto;
            }

        }
    }
}
