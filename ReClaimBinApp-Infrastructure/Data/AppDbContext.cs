using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Configuration;

namespace ReClaimBinApp_Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }


        public DbSet<Manufacturer> manufacturers { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
}