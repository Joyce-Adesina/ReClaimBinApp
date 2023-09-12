using System.ComponentModel.DataAnnotations;

namespace ReClaimBinApp_Core.Dtos.RequestDto
{
    public class UserLoginRequestDto
    {
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}