using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Enum;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    { 
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {

            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;

        }


        public async Task<StandardResponse<IdentityResult>> RegisterAdmin(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            user.UserName = user.Email;
            var createdUser = await _userManager.CreateAsync(user, userRequestDto.Password);
            if (!(createdUser != null && createdUser.Succeeded))
            {
                return StandardResponse<IdentityResult>.Failed(createdUser.Errors.FirstOrDefault().Description, 401);
            }
            var result = await _userManager.AddToRoleAsync(user, userRequestDto.Type.ToString());
            if (!result.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed(result.Errors.FirstOrDefault().Description, 401);
            }
            return StandardResponse<IdentityResult>.Success("successfully register as admin", createdUser, 201);
        }

        public async Task<StandardResponse<IdentityResult>> RegisterUser(UserRequestDto userRequestDto)
        {
            if(userRequestDto.Type==0 || userRequestDto.Type==null)
                throw new InvalidOperationException("UnKnown Membership Type");
            var user = _mapper.Map<User>(userRequestDto);
            user.UserName = user.Email;
            var createdUser = await _userManager.CreateAsync(user, userRequestDto.Password);

            try
            {
                if (createdUser != null && createdUser.Succeeded)
                {
                    switch (userRequestDto.Type)
                    {
                        case MembershipType.Supplier:
                            //_unitOfWork.UserRepository.Create(user);
                            _unitOfWork.SupplierRepository.Create(new Supplier { UserId = user.Id, Name=user.Name });
                            break;
                        case MembershipType.Manufacturer:
                            //_unitOfWork.UserRepository.Create(user);
                            _unitOfWork.ManufacturerRepository.Create(new Manufacturer { UserId = user.Id, Name = user.Name });
                            break;
                        default:
                            throw new InvalidOperationException("UnKnown Membership Type");
                    }
                }
                else
                {
                    return StandardResponse<IdentityResult>.Failed(createdUser.Errors.FirstOrDefault().Description, 401);
                }
            }
            catch (Exception ex)
            {
                return StandardResponse<IdentityResult>.Failed(ex.Message);
            }
            var result = await _userManager.AddToRoleAsync(user, userRequestDto.Type.ToString());
            if(!result.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed(result.Errors.FirstOrDefault().Description, 401);
            }
            return StandardResponse<IdentityResult>.Success("successfully register as user", createdUser, 201);
        }
        public async Task<StandardResponse<string>> LoginUser(UserLoginRequestDto userLoginDto)
        {
            User user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var result = (user != null && await _userManager.CheckPasswordAsync(user, userLoginDto.Password));
            if (!result)
            {
                _logger.LogWarning($"{nameof(LoginUser)}: Authentication failed. Wrong user name or password.");
                return StandardResponse<string>.Failed("Failed", 401);
            }
            var token =await CreateToken(user);
            return StandardResponse<string>.Success("succeeded", token, 201);
        }

        private async Task<string> CreateToken(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims(User _user)
        {
            var claims = new List<Claim>
             {
             new Claim(ClaimTypes.Name, _user.UserName)
             };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
        List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

    }
}
