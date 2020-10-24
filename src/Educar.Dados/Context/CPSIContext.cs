using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Educar.Negocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Educar.Dados.Context
{
    public class CPSIContext : DbContext
    {
        public CPSIContext(DbContextOptions<CPSIContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CPSIContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Disciplina> Disciplinas {get; set;}
        public DbSet<Turma> Turmas { get; set; }
    }
}
