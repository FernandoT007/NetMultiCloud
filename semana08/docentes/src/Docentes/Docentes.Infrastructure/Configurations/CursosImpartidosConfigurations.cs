using Docentes.Domain.CursosImpartidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docentes.Infrastructure.Configurations;

internal sealed class CursosImpartidosConfigurations : IEntityTypeConfiguration<CursoImpartido>
{
    public void Configure(EntityTypeBuilder<CursoImpartido> builder)
    {
        builder.ToTable("cursos_impartidos");
        builder.HasKey(x => x.Id);

        builder.Property(docente => docente.DocenteId);

        builder.Property(curso => curso.CursoId);

        builder.HasOne(docente => docente.Docente)
        .WithMany()
        .HasForeignKey(docente => docente.DocenteId)
        .IsRequired();

        builder.Property<uint>("Version").IsRowVersion();
    }
}