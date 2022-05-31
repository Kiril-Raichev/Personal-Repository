using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum1.Migrations
{
    public partial class blocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 4, "georgi_penev@yahoo.com", "Georgi", "Penev", null, 0, "Gosheto" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 5, "todor_dragunov@yahoo.com", "Todor", "Dragunov", null, 1, "Tosheto" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 6, "dancho_vazov@google.com", "Dancho", "Vazov", null, 1, "Daneto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
