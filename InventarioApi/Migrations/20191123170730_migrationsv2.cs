using Microsoft.EntityFrameworkCore.Migrations;

namespace InventarioApi.Migrations
{
    public partial class migrationsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Compras_CompraIdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleID1",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserID",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleCompras",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_CompraIdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "IdDetalle",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "IdCompra",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "IdCompra",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserRoles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RoleID1",
                table: "UserRoles",
                newName: "RoleId1");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "UserRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleID1",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId1");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Roles",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CodigoDetalle",
                table: "DetalleCompras",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CodigoCompra",
                table: "DetalleCompras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompraCodigoCompra",
                table: "DetalleCompras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoCompra",
                table: "Compras",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleCompras",
                table: "DetalleCompras",
                column: "CodigoDetalle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "CodigoCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraCodigoCompra",
                table: "DetalleCompras",
                column: "CompraCodigoCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Compras_CompraCodigoCompra",
                table: "DetalleCompras",
                column: "CompraCodigoCompra",
                principalTable: "Compras",
                principalColumn: "CodigoCompra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompras_Compras_CompraCodigoCompra",
                table: "DetalleCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleCompras",
                table: "DetalleCompras");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompras_CompraCodigoCompra",
                table: "DetalleCompras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "CodigoDetalle",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "CodigoCompra",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "CompraCodigoCompra",
                table: "DetalleCompras");

            migrationBuilder.DropColumn(
                name: "CodigoCompra",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserRoles",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "RoleId1",
                table: "UserRoles",
                newName: "RoleID1");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserRoles",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleID1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "IdDetalle",
                table: "DetalleCompras",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CompraIdCompra",
                table: "DetalleCompras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCompra",
                table: "DetalleCompras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompra",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleCompras",
                table: "DetalleCompras",
                column: "IdDetalle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompras_CompraIdCompra",
                table: "DetalleCompras",
                column: "CompraIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompras_Compras_CompraIdCompra",
                table: "DetalleCompras",
                column: "CompraIdCompra",
                principalTable: "Compras",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleID1",
                table: "UserRoles",
                column: "RoleID1",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserID",
                table: "UserRoles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
