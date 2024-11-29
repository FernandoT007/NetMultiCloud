﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Usuarios.Infrastructure;

#nullable disable

namespace Usuarios.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241127005324_InitialCreate")]
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

            modelBuilder.Entity("Usuarios.Domain.Roles.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("descripcion");

                    b.Property<string>("NombreRol")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("nombre_rol");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NombreRol")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_nombre_rol");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Usuarios.Domain.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ApellidoMaterno")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("apellido_materno");

                    b.Property<string>("ApellidoPaterno")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("apellido_paterno");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("correo_electronico");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<DateTime>("FechaUltimoCambio")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_ultimo_cambio");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("nombre_usuario");

                    b.Property<string>("NombresPersona")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nombres_persona");

                    b.Property<string>("Password")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("password");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uuid")
                        .HasColumnName("rol_id");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_usuarios");

                    b.HasIndex("RolId")
                        .HasDatabaseName("ix_usuarios_rol_id");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("Usuarios.Domain.Usuarios.Usuario", b =>
                {
                    b.HasOne("Usuarios.Domain.Roles.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_usuarios_roles_rol_id");

                    b.OwnsOne("Usuarios.Domain.Usuarios.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Calle")
                                .HasColumnType("text")
                                .HasColumnName("direccion_calle");

                            b1.Property<string>("Departamento")
                                .HasColumnType("text")
                                .HasColumnName("direccion_departamento");

                            b1.Property<string>("Distrito")
                                .HasColumnType("text")
                                .HasColumnName("direccion_distrito");

                            b1.Property<string>("Pais")
                                .HasColumnType("text")
                                .HasColumnName("direccion_pais");

                            b1.Property<string>("Provincia")
                                .HasColumnType("text")
                                .HasColumnName("direccion_provincia");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId")
                                .HasConstraintName("fk_usuarios_usuarios_id");
                        });

                    b.Navigation("Direccion");

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
