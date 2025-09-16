using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructorLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationHeader",
                columns: table => new
                {
                    EducationHaderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<string>(type: "char(36)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserID = table.Column<string>(type: "char(36)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUserID = table.Column<string>(type: "char(36)", nullable: true),
                    TS = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationHeader", x => x.EducationHaderID);
                    table.ForeignKey(
                        name: "FK_EducationHeader_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationItem",
                columns: table => new
                {
                    EducationItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationHeaderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserID = table.Column<string>(type: "char(36)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUserID = table.Column<string>(type: "char(36)", nullable: true),
                    TS = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationItem", x => x.EducationItemID);
                    table.ForeignKey(
                        name: "FK_EducationItem_EducationHeader_EducationHeaderID",
                        column: x => x.EducationHeaderID,
                        principalTable: "EducationHeader",
                        principalColumn: "EducationHaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationHeader_EmployeeID",
                table: "EducationHeader",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationItem_EducationHeaderID",
                table: "EducationItem",
                column: "EducationHeaderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationItem");

            migrationBuilder.DropTable(
                name: "EducationHeader");
        }
    }
}
