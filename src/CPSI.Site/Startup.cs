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
using Microsoft.CodeAnalysis.Options;
using CPSI.Site.Extensions;

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
            string conexao = _configuration.GetConnectionString("ConnPG");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<CPSIContext>(op => op.UseNpgsql(conexao));

            services.ConfigurarIdentity(conexao);

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllersWithViews()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.CarregarDependencias();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                      areaName: "Diretor",
                      name : "Diretor",
                      pattern: "{area:exists}/{controller=Inicial}/{action=Inicial}"
                    );

                endpoints.MapControllerRoute(
                    name: "Padrao",
                    pattern: "{controller=Inicial}/{action=Inicial}");

                endpoints.MapRazorPages();

            });
        }
    }
}
