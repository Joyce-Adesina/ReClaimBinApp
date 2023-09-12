using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Core.Dtos.RequestDto;
using ReClaimBinApp_Infrastructure.Configuration;

namespace ReClaimBinApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Create(UserRequestDto userRequestDto)
        {
            var result = await _authenticationService.RegisterUser(userRequestDto);
            return StatusCode(result.StatusCode, result);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRequestDto userRequestDto)
        {
            var result = await _authenticationService.RegisterAdmin(userRequestDto);
            return StatusCode(result.StatusCode,result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequestDto requestDto)
        {
            var result = await _authenticationService.LoginUser(requestDto);
            return StatusCode(result.StatusCode,new { Token = result.Data });
        }

    }
}

