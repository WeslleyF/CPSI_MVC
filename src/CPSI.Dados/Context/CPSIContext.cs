using System;
using System.Collections.Generic;
using System.Text;
using CPSI.Negocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CPSI.Dados.Context
{
    public class CPSIContext : DbContext
    {
        public CPSIContext(DbContextOptions<CPSIContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CPSIContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Disciplina> Disciplinas {get; set;}
    }
}
