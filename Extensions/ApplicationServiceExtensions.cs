using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using rar.Infrastructure;
using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("UserDB"));
                //opt.UseSqlServer(config.GetConnectionString("UserDB"));           

                //Register Custom Password (Validation) Services + (built-in validation)
                //services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>();

                //Register Custom Username (Validation) Services + (built-in validation)
                //services.AddTransient<IUserValidator<User>, CustomUserValidator>();
               
            });

            //Identity
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                //Username Options
                opt.User.RequireUniqueEmail = true;

                //Password Options
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            object value = services.AddDbContext<AppDbContext >(opt =>
            {
                //opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                //opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            //MVC - Route Config
            //services.AddMvc(options => options.EnableEndpointRouting = false);

            //Application Service Registration
            services.AddTransient<IAccount, EFAccount>();
            services.AddTransient<IAddress, EFAddress>();          
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      
            return services;
        }
    }
}