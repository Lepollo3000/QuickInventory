using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUICK_INVENTORY.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioCorte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioCorte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioCorte_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioCorte_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventarioCorte_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistroTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroTipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroTipos_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroTipos_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroTipos_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StockMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMedidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockMedidas_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockMedidas_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarras = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Locacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    StockMedidaId = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    StockMaximo = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_StockMedidas_StockMedidaId",
                        column: x => x.StockMedidaId,
                        principalTable: "StockMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioCorteDetalle",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    InventarioCorteId = table.Column<int>(type: "int", nullable: false),
                    StockInicial = table.Column<int>(type: "int", nullable: false),
                    StockFinal = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioCorteDetalle", x => new { x.ProductoId, x.InventarioCorteId });
                    table.ForeignKey(
                        name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                        column: x => x.InventarioCorteId,
                        principalTable: "InventarioCorte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoRegistros",
                columns: table => new
                {
                    Folio = table.Column<int>(type: "int", nullable: false),
                    RegistroTipoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroExterno = table.Column<int>(type: "int", nullable: true),
                    NumeroInterno = table.Column<int>(type: "int", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoRegistros", x => new { x.Folio, x.RegistroTipoId });
                    table.ForeignKey(
                        name: "FK_ProductoRegistros_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRegistros_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoRegistros_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoRegistros_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoRegistros_RegistroTipos_RegistroTipoId",
                        column: x => x.RegistroTipoId,
                        principalTable: "RegistroTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorte_UsuarioAltaId",
                table: "InventarioCorte",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorte_UsuarioEditaId",
                table: "InventarioCorte",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorte_UsuarioEliminaId",
                table: "InventarioCorte",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorteDetalle_InventarioCorteId",
                table: "InventarioCorteDetalle",
                column: "InventarioCorteId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorteDetalle_UsuarioAltaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorteDetalle_UsuarioEditaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioCorteDetalle_UsuarioEliminaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistros_ProductoId",
                table: "ProductoRegistros",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistros_RegistroTipoId",
                table: "ProductoRegistros",
                column: "RegistroTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistros_UsuarioAltaId",
                table: "ProductoRegistros",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistros_UsuarioEditaId",
                table: "ProductoRegistros",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoRegistros_UsuarioEliminaId",
                table: "ProductoRegistros",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_StockMedidaId",
                table: "Productos",
                column: "StockMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioAltaId",
                table: "Productos",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioEditaId",
                table: "Productos",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioEliminaId",
                table: "Productos",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTipos_UsuarioAltaId",
                table: "RegistroTipos",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTipos_UsuarioEditaId",
                table: "RegistroTipos",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTipos_UsuarioEliminaId",
                table: "RegistroTipos",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMedidas_UsuarioAltaId",
                table: "StockMedidas",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMedidas_UsuarioEditaId",
                table: "StockMedidas",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMedidas_UsuarioEliminaId",
                table: "StockMedidas",
                column: "UsuarioEliminaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InventarioCorteDetalle");

            migrationBuilder.DropTable(
                name: "ProductoRegistros");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "InventarioCorte");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RegistroTipos");

            migrationBuilder.DropTable(
                name: "StockMedidas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
