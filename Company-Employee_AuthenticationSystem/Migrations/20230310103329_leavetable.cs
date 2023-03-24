using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class leavetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveStatus",
                table: "Leaves");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Leaves",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeaveStatus",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
