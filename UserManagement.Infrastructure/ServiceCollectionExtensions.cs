using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Application.Services;
using UserManagement.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FlashSaleDB;
namespace UserManagement.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FlashSaleDbContext>(options =>
            options.UseSqlServer(
            configuration.GetConnectionString("FlashSaleDatabase")
            ),
            ServiceLifetime.Scoped);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = configuration["AppSettings:Issuer"],
                         ValidAudience = configuration["AppSettings:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!))
                     };
                 });
            services.AddScoped<IAuthService,AuthService>();
            return services;
        }
    }
}
