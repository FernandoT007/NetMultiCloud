using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Infrastructure.Configurations;

internal sealed class ProgramacionConfigurations : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("programacion");
        builder.HasKey(x => x.Id);

        builder.Property<uint>("Version").IsRowVersion();

    }
}