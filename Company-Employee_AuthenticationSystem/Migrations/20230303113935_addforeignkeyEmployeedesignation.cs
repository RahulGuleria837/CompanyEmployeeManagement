using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class addforeignkeyEmployeedesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations");

          

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDesignations_EmployeeId",
                table: "EmployeeDesignations");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDesignationId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeDesignationId",
                table: "Employees",
                column: "EmployeeDesignationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designations_DesignationId",
                table: "Employees",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeDesignations_EmployeeDesignationId",
                table: "Employees",
                column: "EmployeeDesignationId",
                principalTable: "EmployeeDesignations",
                principalColumn: "EmployeeDesignationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designations_DesignationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeDesignations_EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "DesignationEmployee",
                columns: table => new
                {
                    Employee_DesignationsDesignationId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationEmployee", x => new { x.Employee_DesignationsDesignationId, x.EmployeesEmployeeId });
                    table.ForeignKey(
                        name: "FK_DesignationEmployee_Designations_Employee_DesignationsDesignationId",
                        column: x => x.Employee_DesignationsDesignationId,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignationEmployee_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignations_EmployeeId",
                table: "EmployeeDesignations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationEmployee_EmployeesEmployeeId",
                table: "DesignationEmployee",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
