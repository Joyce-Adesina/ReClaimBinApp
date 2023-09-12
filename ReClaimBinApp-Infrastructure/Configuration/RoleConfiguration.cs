using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReClaimBinApp_Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                 new IdentityRole { Name = "Supplier", NormalizedName = "SUPPLIER" },
                 new IdentityRole { Name = "Manufacturer", NormalizedName = "MANUFACTURER" }
                );
        }
    }
}