using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBrith = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Accounting" },
                    { 4, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBrith", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ayman_shabana@outlook.com", "Ayman", 0, "Shabana", "images/ayman.jpg" },
                    { 2, new DateTime(1951, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mamdouh@farag.com", "Mamdouh", 0, "Farag", "images/mamdouh.jpg" },
                    { 3, new DateTime(1949, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "e3mel@elsa7.com", "Ghassan", 0, "Matar", "images/ghassan.jpg" },
                    { 4, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "elrogoola@elgad3ana.com", "Ahmed", 0, "El Sakka", "images/sakka.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
