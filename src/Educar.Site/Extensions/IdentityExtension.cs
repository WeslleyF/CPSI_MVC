using Educar.Site.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Educar.Site.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection ConfigurarIdentity(this IServiceCollection services, string conexao) 
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<IDentityContext>(options =>
                options.UseSqlServer(conexao)
                );

            services.AddDefaultIdentity<IdentityUser>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<IDentityContext>();

            return services;
        
        }
    }
}
