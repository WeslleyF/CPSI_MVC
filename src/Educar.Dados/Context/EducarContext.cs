using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Educar.Negocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Educar.Dados.Context
{
    public class EducarContext : DbContext
    {
        public EducarContext(DbContextOptions<EducarContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducarContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Disciplina> Disciplinas {get; set;}
        public DbSet<Turma> Turmas {get; set;}
        public DbSet<Documento> Documentos {get; set;}
    }
}
