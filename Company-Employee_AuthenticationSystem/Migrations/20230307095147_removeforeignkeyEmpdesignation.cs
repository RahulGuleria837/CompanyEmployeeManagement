using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class removeforeignkeyEmpdesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeDesignations_EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeDesignationId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignations_EmployeeId",
                table: "EmployeeDesignations",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Employees_EmployeeId",
                table: "EmployeeDesignations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDesignations_EmployeeId",
                table: "EmployeeDesignations");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDesignationId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeDesignationId",
                table: "Employees",
                column: "EmployeeDesignationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeDesignations_EmployeeDesignationId",
                table: "Employees",
                column: "EmployeeDesignationId",
                principalTable: "EmployeeDesignations",
                principalColumn: "EmployeeDesignationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
