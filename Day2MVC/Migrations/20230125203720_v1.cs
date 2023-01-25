using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day2MVC.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESSN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    Bdate = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ESSN = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    deptNumber = table.Column<int>(type: "int", nullable: false),
                    LocationdeptNumber = table.Column<int>(type: "int", nullable: true),
                    location1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.location, x.deptNumber });
                    table.ForeignKey(
                        name: "FK_Locations_Departments_deptNumber",
                        column: x => x.deptNumber,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_location1_LocationdeptNumber",
                        columns: x => new { x.location1, x.LocationdeptNumber },
                        principalTable: "Locations",
                        principalColumns: new[] { "location", "deptNumber" });
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Name, x.SSN });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_SSN",
                        column: x => x.SSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    LocationdeptNumber = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PNumber);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Number");
                    table.ForeignKey(
                        name: "FK_Projects_Locations_location_LocationdeptNumber",
                        columns: x => new { x.location, x.LocationdeptNumber },
                        principalTable: "Locations",
                        principalColumns: new[] { "location", "deptNumber" });
                });

            migrationBuilder.CreateTable(
                name: "Works_s",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    proNumber = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works_s", x => new { x.ESSN, x.proNumber });
                    table.ForeignKey(
                        name: "FK_Works_s_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_s_Projects_proNumber",
                        column: x => x.proNumber,
                        principalTable: "Projects",
                        principalColumn: "PNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ESSN",
                table: "Departments",
                column: "ESSN",
                unique: true,
                filter: "[ESSN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_SSN",
                table: "Dependents",
                column: "SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ESSN",
                table: "Employees",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_deptNumber",
                table: "Locations",
                column: "deptNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_location1_LocationdeptNumber",
                table: "Locations",
                columns: new[] { "location1", "LocationdeptNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_location_LocationdeptNumber",
                table: "Projects",
                columns: new[] { "location", "LocationdeptNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Works_s_proNumber",
                table: "Works_s",
                column: "proNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ESSN",
                table: "Departments",
                column: "ESSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ESSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Works_s");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
