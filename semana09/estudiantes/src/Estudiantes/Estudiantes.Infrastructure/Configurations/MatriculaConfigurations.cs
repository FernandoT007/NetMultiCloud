using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estudiantes.Domain.Matriculas;
using Estudiantes.Domain.Estudiantes;

namespace Estudiantes.Infrastructure.Configurations;

internal sealed class UsuarioConfigurations : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("matricula");
        builder.HasKey(x => x.Id); //PK

        builder.Property(docente => docente.ProgramacionId);

        builder.Property(estudiante => estudiante.EstudianteId);

        builder.HasOne(estudiante => estudiante.Estudiante)
        .WithMany()
        .HasForeignKey(estudiante => estudiante.EstudianteId)
        .IsRequired();

        builder.HasOne(programacion => programacion.Programacion)
        .WithMany()
        .HasForeignKey(programacion => programacion.ProgramacionId)
        .IsRequired();

        builder.Property<uint>("Version").IsRowVersion();

    }
}