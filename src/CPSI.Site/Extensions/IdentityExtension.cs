using CPSI.Site.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CPSI.Site.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection ConfigurarIdentity(this IServiceCollection services, string conexao) 
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<IDentityContext>(options =>
                options.UseNpgsql(conexao)
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
