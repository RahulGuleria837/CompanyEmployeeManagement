using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Employee_AuthenticationSystem.Migrations
{
    public partial class leaveproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveTaken",
                table: "Leaves",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Leaves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Leaves");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Leaves",
                newName: "LeaveTaken");
        }
    }
}
