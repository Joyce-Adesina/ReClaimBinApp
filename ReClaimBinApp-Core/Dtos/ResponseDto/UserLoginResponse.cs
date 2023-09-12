using System.ComponentModel.DataAnnotations;

namespace ReClaimBinApp_Core.Dtos.ResponseDto
{
    public class UserLoginResponse
    {
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}