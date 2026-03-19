using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixedTableStructureForUserPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "RolePermissions");

            migrationBuilder.AddColumn<string>(
                name: "MenuID",
                table: "RolePermissions",
                type: "char(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_MenuID",
                table: "RolePermissions",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Menus_MenuID",
                table: "RolePermissions",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "MenuID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Menus_MenuID",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_MenuID",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "RolePermissions");

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Order",
                table: "RolePermissions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
