using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class DesignationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "EmployeeDesignations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDesignations_DesignationId",
                table: "EmployeeDesignations",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDesignations_DesignationId",
                table: "EmployeeDesignations");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "EmployeeDesignations");
        }
    }
}
