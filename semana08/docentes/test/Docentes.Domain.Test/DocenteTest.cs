using Docentes.Domain.Docentes;
using FluentAssertions;

namespace Docentes.Domain.Test
{
    public class DocenteTest
    {
        [Fact]
        public void Create_ShouldReturnSuccessResult_WhenValidParameters()
        {
            var usuarioId = Guid.NewGuid();
            var especialidadId = Guid.NewGuid();

            var result = Docente.Create(usuarioId,especialidadId);

            result.IsSuccess.Should().BeTrue();
            result.Value.UsuarioId.Should().Be(usuarioId);
            result.Value.EspecialidadId.Should().Be(especialidadId);
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public void Create_ShouldGenerateNewId_ForNewDocente()
        {
            var usuarioId = Guid.NewGuid();
            var especialidadId = Guid.NewGuid();

            var result = Docente.Create(usuarioId,especialidadId);

            result.Value.Id.Should().NotBe(Guid.Empty);
        }
    }
}