using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estudiante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    curso_id = table.Column<Guid>(type: "uuid", nullable: false),
                    docente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    fecha_ultimo_cambio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_programacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    estudiante_id = table.Column<Guid>(type: "uuid", nullable: false),
                    programacion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_matricula = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estado_matricula = table.Column<int>(type: "integer", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matricula", x => x.id);
                    table.ForeignKey(
                        name: "fk_matricula_estudiante_estudiante_id",
                        column: x => x.estudiante_id,
                        principalTable: "estudiante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_matricula_programacion_programacion_id",
                        column: x => x.programacion_id,
                        principalTable: "programacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_estudiante_usuario_id",
                table: "estudiante",
                column: "usuario_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_matricula_estudiante_id",
                table: "matricula",
                column: "estudiante_id");

            migrationBuilder.CreateIndex(
                name: "ix_matricula_programacion_id",
                table: "matricula",
                column: "programacion_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "programacion");
        }
    }
}
