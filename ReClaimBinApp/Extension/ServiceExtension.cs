using Microsoft.AspNetCore.Identity;
using ReClaimBinApp_Application.Service.Abstraction;
using ReClaimBinApp_Application.Service.Implementation;
using ReClaimBinApp_Core.Model;
using ReClaimBinApp_Infrastructure.Data;
using ReClaimBinApp_Infrastructure.UnitOfWork.Abstraction;
using ReClaimBinApp_Infrastructure.UnitOfWork.Implementation;

namespace ReClaimBinApp.Extension
{
    public static class ServiceExtension
    {
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IOrderService,OrderService>();
           
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false ;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
