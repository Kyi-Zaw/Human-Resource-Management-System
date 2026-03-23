using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class RoleIDInRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleID",
                table: "RolePermissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "RolePermissions");
        }
    }
}
