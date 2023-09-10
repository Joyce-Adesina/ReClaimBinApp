using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using ReClaimBinApp_Core.Enum;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<StandardResponse<IdentityResult>> RegisterUser(UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            var created = await _userManager.CreateAsync(user, userRequestDto.Password);

            try
            {
                if (created != null && created.Succeeded)
                {
                    switch (userRequestDto.Type)
                    {
                        case MembershipType.Supplier:
                            _unitOfWork.UserRepository.Create(user);
                            _unitOfWork.SupplierRepository.Create(new Supplier { UserId = user.Id });
                            break;
                        case MembershipType.Manufacturer:
                            _unitOfWork.UserRepository.Create(user);
                            _unitOfWork.ManufacturerRepository.Create(new Manufacturer { UserId = user.Id });
                            break;
                        default:
                            throw new InvalidOperationException("UnKnown Membership Type");
                    }
                }
            }
            catch (Exception ex)
            {
                return StandardResponse<IdentityResult>.Failed(ex.Message);
            }
            return StandardResponse<IdentityResult>.Success("succeeded", created);
        }
    }   
}
