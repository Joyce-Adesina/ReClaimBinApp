using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;

namespace ReClaimBinApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService )
        {
            _authenticationService = authenticationService;
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRequestDto userRequestDto)
        {
            var add =  await _authenticationService.RegisterUser(userRequestDto);
            return Ok(add);
        }
    }
}
