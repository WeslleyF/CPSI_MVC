using CPSI.Dados.Repository;
using CPSI.Negocio.Interface;
using CPSI.Negocio.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPSI.Site.Extensions
{
    //Classe para Injenção de depedência para diminuir poluição visual da Startup
    public static class DIExtension
    {
        public static IServiceCollection CarregarDependencias(this IServiceCollection services) 
        {
            //Injeção de dependência
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaService, TurmaService>();

            return services;
        }
    }
}
