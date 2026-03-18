using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "RolePermissions");
        }
    }
}
