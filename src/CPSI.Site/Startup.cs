using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using CPSI.Dados.Context;
using Microsoft.Extensions.Configuration;
using CPSI.Negocio.Interface;
using CPSI.Negocio.Service;
using CPSI.Dados.Repository;
using CPSI.Site.Data;
using Microsoft.AspNetCore.Identity;

namespace CPSI.Site
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<CPSIContext>(op => op.UseNpgsql(_configuration.GetConnectionString("ConnPG")));

            //Configuração do Identity
            
            services.AddEntityFrameworkNpgsql().AddDbContext<IDentityContext>(options =>
                    options.UseNpgsql(
                        _configuration.GetConnectionString("ConnPG")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IDentityContext>();

            //

            services.AddMvc();

            services.AddMvc()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            //Injeção de dependência
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Padrao",
                    pattern: "{controller=Inicial}/{action=Inicial}");


            });
        }
    }
}
