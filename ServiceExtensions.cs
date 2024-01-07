using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repos;
using System.Net.Mail;
using System.Text;

namespace Bar_Management_System
{
    public static class ServiceExtensions
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
            var key = configuration["JWT:TokenKey"];//"asdfa-dfadf-fasdf-fasdf-afsdf";
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    ValidAudience = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Unit of work(repo list)
            services.AddTransient<IUnitOfWork, UnitOfWork>();
           /* services.AddScoped<IEmailMessage, EmailMessage>();
            services.AddScoped<IDocTypeNotification, DocTypeNotification>();
            services.AddScoped<ITicketRealTimeDataService, TicketRealTimeDataService>();
            services.AddScoped<ITicketService, TicketService>();*/
        }
    }
}
