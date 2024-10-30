using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUICK_INVENTORY.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregadosModelosPrincipales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CodigoBarras = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                name: "ProductoRegistros",
                columns: table => new
                {
                    Folio = table.Column<int>(type: "int", nullable: false),
                    RegistroTipoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
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
                name: "ProductoRegistros");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "RegistroTipos");

            migrationBuilder.DropTable(
                name: "StockMedidas");
        }
    }
}
