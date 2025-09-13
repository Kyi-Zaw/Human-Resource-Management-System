using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserID = table.Column<string>(type: "char(36)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUserID = table.Column<string>(type: "char(36)", nullable: true),
                    TS = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "PostInfo",
                columns: table => new
                {
                    PostID = table.Column<string>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserID = table.Column<string>(type: "char(36)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUserID = table.Column<string>(type: "char(36)", nullable: true),
                    TS = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfo", x => x.PostID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PostInfo");
        }
    }
}
