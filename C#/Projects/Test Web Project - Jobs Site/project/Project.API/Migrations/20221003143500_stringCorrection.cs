using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.API.Migrations
{
    public partial class stringCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Job",
                value: ".NET");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Job",
                value: ".Net");
        }
    }
}
