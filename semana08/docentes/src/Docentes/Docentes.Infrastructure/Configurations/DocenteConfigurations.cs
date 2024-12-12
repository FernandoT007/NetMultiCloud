using Docentes.Domain.Docentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docentes.Infrastructure.Configurations;

public class DocenteConfigurations : IEntityTypeConfiguration<Docente>
{
      public void Configure(EntityTypeBuilder<Docente> builder)
    {
        builder.ToTable("docentes");
        builder.HasKey(x => x.Id);

        builder.Property(usuario => usuario.UsuarioId);

        builder.HasIndex(usuario => usuario.UsuarioId).IsUnique();

        builder.Property(especialidad => especialidad.EspecialidadId);

        builder.Property<uint>("Version").IsRowVersion();
    }
}