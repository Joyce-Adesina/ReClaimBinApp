using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReClaimBinApp_Core.Model
{
    public class User : IdentityUser
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileImage { get; set; }


       
    }
}
