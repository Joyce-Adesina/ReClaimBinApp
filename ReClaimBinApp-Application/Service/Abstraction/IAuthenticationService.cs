using Microsoft.AspNetCore.Identity;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Core.Dtos.ResponseDto;

namespace ReClaimBinApp_Application.Service.Abstraction
{
    public interface IAuthenticationService
    {
        Task<StandardResponse<IdentityResult>> RegisterUser(UserRequestDto userRequestDto);
        Task<StandardResponse<IdentityResult>> RegisterAdmin(UserRequestDto userRequestDto);
        Task<StandardResponse<string>> LoginUser(UserLoginRequestDto userLoginDto);
    }
}