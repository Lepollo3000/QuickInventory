using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QUICK_INVENTORY.Data.Migrations
{
    /// <inheritdoc />
    public partial class CambioEnCodigoBarras : Migration
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
                name: "FK_ProductoRegistros_AspNetUsers_UsuarioAltaId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoRegistros_Productos_ProductoId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoRegistros_RegistroTipos_RegistroTipoId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTipos_AspNetUsers_UsuarioAltaId",
                table: "RegistroTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Productos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_ProductoRegistros_AspNetUsers_UsuarioAltaId",
                table: "ProductoRegistros",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoRegistros_Productos_ProductoId",
                table: "ProductoRegistros",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoRegistros_RegistroTipos_RegistroTipoId",
                table: "ProductoRegistros",
                column: "RegistroTipoId",
                principalTable: "RegistroTipos",
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
                name: "FK_RegistroTipos_AspNetUsers_UsuarioAltaId",
                table: "RegistroTipos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
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
                name: "FK_ProductoRegistros_AspNetUsers_UsuarioAltaId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoRegistros_Productos_ProductoId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoRegistros_RegistroTipos_RegistroTipoId",
                table: "ProductoRegistros");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_AspNetUsers_UsuarioAltaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_StockMedidas_StockMedidaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTipos_AspNetUsers_UsuarioAltaId",
                table: "RegistroTipos");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMedidas_AspNetUsers_UsuarioAltaId",
                table: "StockMedidas");

            migrationBuilder.AlterColumn<Guid>(
                name: "CodigoBarras",
                table: "Productos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

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
                name: "FK_ProductoRegistros_AspNetUsers_UsuarioAltaId",
                table: "ProductoRegistros",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoRegistros_Productos_ProductoId",
                table: "ProductoRegistros",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoRegistros_RegistroTipos_RegistroTipoId",
                table: "ProductoRegistros",
                column: "RegistroTipoId",
                principalTable: "RegistroTipos",
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
                name: "FK_RegistroTipos_AspNetUsers_UsuarioAltaId",
                table: "RegistroTipos",
                column: "UsuarioAltaId",
                principalTable: "AspNetUsers",
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
