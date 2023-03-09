using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle_E_Learning_Platform.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "If your goal is to get in shape and fit then look no more, with a few fast sessions you will have all the information you need to complete your goals!", "Physical Training" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Sign up now and to learn from our best teacher how to create industry competitive designs that will shock everyone around you!", "Graphic Design" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "Title" },
                values: new object[] { "Interested in programming, but you have no idea where to start? Try out this free short intro course to see if the C# language is for you!", 30, "C# Programming Basics" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Title" },
                values: new object[] { "In this section you will learn how to install the necessary programs and run your first real code.", "Hello World" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Learn all the different operations you can put in your code.", "Basic Operations" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Here you are introduced to the different ways you can use code to create cycles and manipulate them.", "Loops and cycles" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Password" },
                values: new object[] { "Georgiev", "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The best course in here, trust", "Course no1" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The second best course in here, trust", "Course no2" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "Title" },
                values: new object[] { "The third best course in here, trust", 198, "Course no3" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Description of the first test section", "First test section" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Description of the second test section", "Second test section" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Description of the third test section", "Third test section" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Password" },
                values: new object[] { "Geirgiev", "1223" });
        }
    }
}
