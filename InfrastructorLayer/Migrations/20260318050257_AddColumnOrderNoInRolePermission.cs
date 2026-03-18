using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnOrderNoInRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderNo",
                table: "RolePermissions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "RolePermissions");
        }
    }
}
