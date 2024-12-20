﻿// <auto-generated />
using System;
using Estudiantes.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Estudiantes.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241217172746_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Estudiantes.Domain.Estudiantes.Estudiante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid")
                        .HasColumnName("usuario_id");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_estudiante");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasDatabaseName("ix_estudiante_usuario_id");

                    b.ToTable("estudiante", (string)null);
                });

            modelBuilder.Entity("Estudiantes.Domain.Matriculas.Matricula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("EstadoMatricula")
                        .HasColumnType("integer")
                        .HasColumnName("estado_matricula");

                    b.Property<Guid>("EstudianteId")
                        .HasColumnType("uuid")
                        .HasColumnName("estudiante_id");

                    b.Property<DateTime>("FechaMatricula")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_matricula");

                    b.Property<Guid>("ProgramacionId")
                        .HasColumnType("uuid")
                        .HasColumnName("programacion_id");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_matricula");

                    b.HasIndex("EstudianteId")
                        .HasDatabaseName("ix_matricula_estudiante_id");

                    b.HasIndex("ProgramacionId")
                        .HasDatabaseName("ix_matricula_programacion_id");

                    b.ToTable("matricula", (string)null);
                });

            modelBuilder.Entity("Estudiantes.Domain.Programaciones.Programacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uuid")
                        .HasColumnName("curso_id");

                    b.Property<Guid>("DocenteId")
                        .HasColumnType("uuid")
                        .HasColumnName("docente_id");

                    b.Property<int>("Estado")
                        .HasColumnType("integer")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaUltimoCambio")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_ultimo_cambio");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_programacion");

                    b.ToTable("programacion", (string)null);
                });

            modelBuilder.Entity("Estudiantes.Domain.Matriculas.Matricula", b =>
                {
                    b.HasOne("Estudiantes.Domain.Estudiantes.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_matricula_estudiante_estudiante_id");

                    b.HasOne("Estudiantes.Domain.Programaciones.Programacion", "Programacion")
                        .WithMany()
                        .HasForeignKey("ProgramacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_matricula_programacion_programacion_id");

                    b.Navigation("Estudiante");

                    b.Navigation("Programacion");
                });
#pragma warning restore 612, 618
        }
    }
}
