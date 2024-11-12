using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUICK_INVENTORY.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesParaProductoMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorte");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.DropTable(
                name: "ProductoRegistros");

            migrationBuilder.DropTable(
                name: "RegistroTipos");

            migrationBuilder.CreateTable(
                name: "MovimientoTipos",
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
                    table.PrimaryKey("PK_MovimientoTipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoTipos_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoTipos_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientoTipos_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoMovimientos",
                columns: table => new
                {
                    Folio = table.Column<int>(type: "int", nullable: false),
                    MovimientoTipoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_ProductoMovimientos", x => new { x.Folio, x.MovimientoTipoId });
                    table.ForeignKey(
                        name: "FK_ProductoMovimientos_AspNetUsers_UsuarioAltaId",
                        column: x => x.UsuarioAltaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoMovimientos_AspNetUsers_UsuarioEditaId",
                        column: x => x.UsuarioEditaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoMovimientos_AspNetUsers_UsuarioEliminaId",
                        column: x => x.UsuarioEliminaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoMovimientos_MovimientoTipos_MovimientoTipoId",
                        column: x => x.MovimientoTipoId,
                        principalTable: "MovimientoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoMovimientos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoTipos_UsuarioAltaId",
                table: "MovimientoTipos",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoTipos_UsuarioEditaId",
                table: "MovimientoTipos",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoTipos_UsuarioEliminaId",
                table: "MovimientoTipos",
                column: "UsuarioEliminaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimientos_MovimientoTipoId",
                table: "ProductoMovimientos",
                column: "MovimientoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimientos_ProductoId",
                table: "ProductoMovimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimientos_UsuarioAltaId",
                table: "ProductoMovimientos",
                column: "UsuarioAltaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimientos_UsuarioEditaId",
                table: "ProductoMovimientos",
                column: "UsuarioEditaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimientos_UsuarioEliminaId",
                table: "ProductoMovimientos",
                column: "UsuarioEliminaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorte",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                table: "InventarioCorteDetalle",
                column: "InventarioCorteId",
                principalTable: "InventarioCorte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                table: "InventarioCorteDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos",
                column: "StockMedidaId",
                principalTable: "StockMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorte");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.DropTable(
                name: "ProductoMovimientos");

            migrationBuilder.DropTable(
                name: "MovimientoTipos");

            migrationBuilder.CreateTable(
                name: "RegistroTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "ProductoRegistros",
                columns: table => new
                {
                    Folio = table.Column<int>(type: "int", nullable: false),
                    RegistroTipoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAltaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEditaId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEliminaId = table.Column<int>(type: "int", nullable: true),
                    Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroExterno = table.Column<int>(type: "int", nullable: true),
                    NumeroInterno = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorte",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                table: "InventarioCorteDetalle",
                column: "InventarioCorteId",
                principalTable: "InventarioCorte",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                table: "InventarioCorteDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos",
                column: "StockMedidaId",
                principalTable: "StockMedidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
