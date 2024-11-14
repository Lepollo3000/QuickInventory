using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUICK_INVENTORY.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregadosCortesInventario : Migration
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
                name: "FK_InventarioCorte_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorte");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorte");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_InventarioCorte_InventarioCorteId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalle_Productos_ProductoId",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoTipos_AspNetUsers_UsuarioAltaId",
                table: "MovimientoTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_AspNetUsers_UsuarioAltaId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_MovimientoTipos_MovimientoTipoId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_Productos_ProductoId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventarioCorteDetalle",
                table: "InventarioCorteDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventarioCorte",
                table: "InventarioCorte");

            migrationBuilder.RenameTable(
                name: "InventarioCorteDetalle",
                newName: "InventarioCorteDetalles");

            migrationBuilder.RenameTable(
                name: "InventarioCorte",
                newName: "InventarioCortes");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalle_UsuarioEliminaId",
                table: "InventarioCorteDetalles",
                newName: "IX_InventarioCorteDetalles_UsuarioEliminaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalle_UsuarioEditaId",
                table: "InventarioCorteDetalles",
                newName: "IX_InventarioCorteDetalles_UsuarioEditaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalle_UsuarioAltaId",
                table: "InventarioCorteDetalles",
                newName: "IX_InventarioCorteDetalles_UsuarioAltaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalle_InventarioCorteId",
                table: "InventarioCorteDetalles",
                newName: "IX_InventarioCorteDetalles_InventarioCorteId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorte_UsuarioEliminaId",
                table: "InventarioCortes",
                newName: "IX_InventarioCortes_UsuarioEliminaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorte_UsuarioEditaId",
                table: "InventarioCortes",
                newName: "IX_InventarioCortes_UsuarioEditaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorte_UsuarioAltaId",
                table: "InventarioCortes",
                newName: "IX_InventarioCortes_UsuarioAltaId");

            migrationBuilder.AlterColumn<int>(
                name: "StockFinal",
                table: "InventarioCorteDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventarioCorteDetalles",
                table: "InventarioCorteDetalles",
                columns: new[] { "ProductoId", "InventarioCorteId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventarioCortes",
                table: "InventarioCortes",
                column: "Id");

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
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalles",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorteDetalles",
                column: "UsuarioEditaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorteDetalles",
                column: "UsuarioEliminaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalles_InventarioCortes_InventarioCorteId",
                table: "InventarioCorteDetalles",
                column: "InventarioCorteId",
                principalTable: "InventarioCortes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalles_Productos_ProductoId",
                table: "InventarioCorteDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioAltaId",
                table: "InventarioCortes",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioEditaId",
                table: "InventarioCortes",
                column: "UsuarioEditaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCortes",
                column: "UsuarioEliminaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoTipos_AspNetUsers_UsuarioAltaId",
                table: "MovimientoTipos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_AspNetUsers_UsuarioAltaId",
                table: "ProductoMovimientos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_MovimientoTipos_MovimientoTipoId",
                table: "ProductoMovimientos",
                column: "MovimientoTipoId",
                principalTable: "MovimientoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_Productos_ProductoId",
                table: "ProductoMovimientos",
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
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorteDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalles_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorteDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalles_InventarioCortes_InventarioCorteId",
                table: "InventarioCorteDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCorteDetalles_Productos_ProductoId",
                table: "InventarioCorteDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioAltaId",
                table: "InventarioCortes");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioEditaId",
                table: "InventarioCortes");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioCortes_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCortes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoTipos_AspNetUsers_UsuarioAltaId",
                table: "MovimientoTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_AspNetUsers_UsuarioAltaId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_MovimientoTipos_MovimientoTipoId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMovimientos_Productos_ProductoId",
                table: "ProductoMovimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventarioCortes",
                table: "InventarioCortes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventarioCorteDetalles",
                table: "InventarioCorteDetalles");

            migrationBuilder.RenameTable(
                name: "InventarioCortes",
                newName: "InventarioCorte");

            migrationBuilder.RenameTable(
                name: "InventarioCorteDetalles",
                newName: "InventarioCorteDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCortes_UsuarioEliminaId",
                table: "InventarioCorte",
                newName: "IX_InventarioCorte_UsuarioEliminaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCortes_UsuarioEditaId",
                table: "InventarioCorte",
                newName: "IX_InventarioCorte_UsuarioEditaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCortes_UsuarioAltaId",
                table: "InventarioCorte",
                newName: "IX_InventarioCorte_UsuarioAltaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalles_UsuarioEliminaId",
                table: "InventarioCorteDetalle",
                newName: "IX_InventarioCorteDetalle_UsuarioEliminaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalles_UsuarioEditaId",
                table: "InventarioCorteDetalle",
                newName: "IX_InventarioCorteDetalle_UsuarioEditaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalles_UsuarioAltaId",
                table: "InventarioCorteDetalle",
                newName: "IX_InventarioCorteDetalle_UsuarioAltaId");

            migrationBuilder.RenameIndex(
                name: "IX_InventarioCorteDetalles_InventarioCorteId",
                table: "InventarioCorteDetalle",
                newName: "IX_InventarioCorteDetalle_InventarioCorteId");

            migrationBuilder.AlterColumn<int>(
                name: "StockFinal",
                table: "InventarioCorteDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventarioCorte",
                table: "InventarioCorte",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventarioCorteDetalle",
                table: "InventarioCorteDetalle",
                columns: new[] { "ProductoId", "InventarioCorteId" });

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
                name: "FK_InventarioCorte_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorte",
                column: "UsuarioEditaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorte_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorte",
                column: "UsuarioEliminaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioAltaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEditaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioEditaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioCorteDetalle_AspNetUsers_UsuarioEliminaId",
                table: "InventarioCorteDetalle",
                column: "UsuarioEliminaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_MovimientoTipos_AspNetUsers_UsuarioAltaId",
                table: "MovimientoTipos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_AspNetUsers_UsuarioAltaId",
                table: "ProductoMovimientos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_MovimientoTipos_MovimientoTipoId",
                table: "ProductoMovimientos",
                column: "MovimientoTipoId",
                principalTable: "MovimientoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMovimientos_Productos_ProductoId",
                table: "ProductoMovimientos",
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
