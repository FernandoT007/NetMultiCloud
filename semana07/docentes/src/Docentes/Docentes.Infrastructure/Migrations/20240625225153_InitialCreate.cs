using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Docentes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    especialidad_id = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_docentes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cursos_impartidos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    docente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    curso_id = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cursos_impartidos", x => x.id);
                    table.ForeignKey(
                        name: "fk_cursos_impartidos_docente_docente_id",
                        column: x => x.docente_id,
                        principalTable: "docentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cursos_impartidos_docente_id",
                table: "cursos_impartidos",
                column: "docente_id");

            migrationBuilder.CreateIndex(
                name: "ix_docentes_usuario_id",
                table: "docentes",
                column: "usuario_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cursos_impartidos");

            migrationBuilder.DropTable(
                name: "docentes");
        }
    }
}
