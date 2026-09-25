using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces;
using School.Application.Services;
using School.Domain.Interfaces;
using School.Infra.Data.Context;
using School.Infra.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using School.Domain.Account;
using School.Infra.Data.Identity;

namespace School.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<INotaService, NotaService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            return services;
        }
    }
}