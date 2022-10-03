using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "Job" },
                values: new object[] { "Ivan Ivanov", ".NET" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Job", "Username" },
                values: new object[] { ".Net", "Ivan Ivanov" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Job", "Username" },
                values: new object[] { "Georgi_Georgiev@abv.bg", "Java", "Georgi Georgiev" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "Job" },
                values: new object[] { "IvanIvanov", ".Net Developer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Job", "Username" },
                values: new object[] { ".Net Developer", "IvanIvanov" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Job", "Username" },
                values: new object[] { "Geororgi_Georgiev@abv.bg", "C# Developer", "GeorgiGeorgiev" });
        }
    }
}
