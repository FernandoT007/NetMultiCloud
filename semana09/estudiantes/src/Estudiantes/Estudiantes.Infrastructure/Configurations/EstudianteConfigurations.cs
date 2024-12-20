using Estudiantes.Domain.Estudiantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estudiantes.Infrastructure.Configurations;

public class EstudiantesConfigurations : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
        builder.ToTable("estudiante");
        builder.HasKey(x => x.Id);

        builder.HasIndex(rol => rol.UsuarioId).IsUnique();

        builder.Property<uint>("Version").IsRowVersion();
    }
}