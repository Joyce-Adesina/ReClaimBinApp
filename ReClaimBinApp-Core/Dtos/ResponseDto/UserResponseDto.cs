using ReClaimBinApp_Core.Enum;

namespace ReClaimBinApp_Core.Dtos.ResponseDto
{
    public class UserResponseDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public MembershipType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}