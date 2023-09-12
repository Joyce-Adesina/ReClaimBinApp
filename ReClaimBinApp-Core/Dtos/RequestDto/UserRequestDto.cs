using ReClaimBinApp_Core.Enum;

namespace ReClaimBinApp_Core.Dtos.RequestDto
{
    public class UserRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public MembershipType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}