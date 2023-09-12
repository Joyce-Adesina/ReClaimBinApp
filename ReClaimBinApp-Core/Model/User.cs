using Microsoft.AspNetCore.Identity;

namespace ReClaimBinApp_Core.Model
{
    public class User : IdentityUser
    { 
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }
    }
}