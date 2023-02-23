using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class allownullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "EmployeeDesignations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "EmployeeDesignations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDesignations_Designations_DesignationId",
                table: "EmployeeDesignations",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
