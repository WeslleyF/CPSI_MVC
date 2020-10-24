using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Educar.Negocio.Modelo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educar.Dados.Mappings
{
    class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(T => T.Id);

            builder.Property(T => T.Nome)
                .IsRequired()
                .HasColumnType("Varchar(100)");

            builder.Property(T => T.Horario)
                .HasColumnType("Varchar(100)");
        }
    }
}
