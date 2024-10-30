﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QUICK_INVENTORY.Server.Data;

#nullable disable

namespace QUICK_INVENTORY.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241027171916_AgregadosModelosPrincipales")]
    partial class AgregadosModelosPrincipales
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("bit");

                    b.Property<string>("Use")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.IdentidadRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoBarras")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<string>("Locacion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockMaximo")
                        .HasColumnType("int");

                    b.Property<int>("StockMedidaId")
                        .HasColumnType("int");

                    b.Property<int>("StockMinimo")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioAltaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEditaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEliminaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockMedidaId");

                    b.HasIndex("UsuarioAltaId");

                    b.HasIndex("UsuarioEditaId");

                    b.HasIndex("UsuarioEliminaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.ProductoRegistro", b =>
                {
                    b.Property<int>("Folio")
                        .HasColumnType("int");

                    b.Property<int>("RegistroTipoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumeroExterno")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroInterno")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioAltaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEditaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEliminaId")
                        .HasColumnType("int");

                    b.HasKey("Folio", "RegistroTipoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("RegistroTipoId");

                    b.HasIndex("UsuarioAltaId");

                    b.HasIndex("UsuarioEditaId");

                    b.HasIndex("UsuarioEliminaId");

                    b.ToTable("ProductoRegistros");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.RegistroTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioAltaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEditaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEliminaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAltaId");

                    b.HasIndex("UsuarioEditaId");

                    b.HasIndex("UsuarioEliminaId");

                    b.ToTable("RegistroTipos");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.StockMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaEliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioAltaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEditaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioEliminaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAltaId");

                    b.HasIndex("UsuarioEditaId");

                    b.HasIndex("UsuarioEliminaId");

                    b.ToTable("StockMedidas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadRol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadRol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.Producto", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.StockMedida", "StockMedida")
                        .WithMany("Productos")
                        .HasForeignKey("StockMedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioAlta")
                        .WithMany()
                        .HasForeignKey("UsuarioAltaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioEdita")
                        .WithMany()
                        .HasForeignKey("UsuarioEditaId");

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioElimina")
                        .WithMany()
                        .HasForeignKey("UsuarioEliminaId");

                    b.Navigation("StockMedida");

                    b.Navigation("UsuarioAlta");

                    b.Navigation("UsuarioEdita");

                    b.Navigation("UsuarioElimina");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.ProductoRegistro", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.Producto", "Producto")
                        .WithMany("Registros")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.RegistroTipo", "RegistroTipo")
                        .WithMany("Registros")
                        .HasForeignKey("RegistroTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioAlta")
                        .WithMany()
                        .HasForeignKey("UsuarioAltaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioEdita")
                        .WithMany()
                        .HasForeignKey("UsuarioEditaId");

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioElimina")
                        .WithMany()
                        .HasForeignKey("UsuarioEliminaId");

                    b.Navigation("Producto");

                    b.Navigation("RegistroTipo");

                    b.Navigation("UsuarioAlta");

                    b.Navigation("UsuarioEdita");

                    b.Navigation("UsuarioElimina");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.RegistroTipo", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioAlta")
                        .WithMany()
                        .HasForeignKey("UsuarioAltaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioEdita")
                        .WithMany()
                        .HasForeignKey("UsuarioEditaId");

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioElimina")
                        .WithMany()
                        .HasForeignKey("UsuarioEliminaId");

                    b.Navigation("UsuarioAlta");

                    b.Navigation("UsuarioEdita");

                    b.Navigation("UsuarioElimina");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.StockMedida", b =>
                {
                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioAlta")
                        .WithMany()
                        .HasForeignKey("UsuarioAltaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioEdita")
                        .WithMany()
                        .HasForeignKey("UsuarioEditaId");

                    b.HasOne("QUICK_INVENTORY.Server.Domain.IdentidadUsuario", "UsuarioElimina")
                        .WithMany()
                        .HasForeignKey("UsuarioEliminaId");

                    b.Navigation("UsuarioAlta");

                    b.Navigation("UsuarioEdita");

                    b.Navigation("UsuarioElimina");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.Producto", b =>
                {
                    b.Navigation("Registros");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.RegistroTipo", b =>
                {
                    b.Navigation("Registros");
                });

            modelBuilder.Entity("QUICK_INVENTORY.Server.Domain.StockMedida", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
