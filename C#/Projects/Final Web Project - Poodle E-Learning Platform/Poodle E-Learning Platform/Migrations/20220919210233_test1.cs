using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle_E_Learning_Platform.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Duration", "ImgSource", "Title" },
                values: new object[] { "Interested in programming, but you have no idea where to start? Try out this free short intro course to see if the C# language is for you!", 30, "https://st.depositphotos.com/1075946/1820/i/450/depositphotos_18206843-stock-photo-group-of-young-in-training.jpg", "C# Programming Basics" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "ImgSource", "Title" },
                values: new object[] { "If your goal is to get in shape and fit then look no more, with a few fast sessions you will have all the information you need to complete your goals!", 110, "~/img/test1.jpg", "Physical Training" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Duration", "ImgSource", "Title" },
                values: new object[] { "If your goal is to get in shape and fit then look no more, with a few fast sessions you will have all the information you need to complete your goals!", 110, "~/img/test1.jpg", "Physical Training" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "ImgSource", "Title" },
                values: new object[] { "Interested in programming, but you have no idea where to start? Try out this free short intro course to see if the C# language is for you!", 30, "https://st.depositphotos.com/1075946/1820/i/450/depositphotos_18206843-stock-photo-group-of-young-in-training.jpg", "C# Programming Basics" });
        }
    }
}
