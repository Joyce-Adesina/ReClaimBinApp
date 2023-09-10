using Microsoft.AspNetCore.Identity;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface IAuthenticationService
    {
        Task<StandardResponse<IdentityResult>> RegisterUser(UserRequestDto userRequestDto);
        //Task<bool> ValidateUser(UserLoginDto, userLoginDto);
        //Task<string> CreateToken();
    }
}
