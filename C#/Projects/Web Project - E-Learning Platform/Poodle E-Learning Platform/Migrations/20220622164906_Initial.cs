using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poodle_E_Learning_Platform.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ImgSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => new { x.CourseId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedBy", "Description", "Duration", "ImgSource", "Title", "Visibility" },
                values: new object[,]
                {
                    { 1, "Ivan Ivanov", "The best course in here, trust", 110, "~/img/test1.jpg", "Course no1", 0 },
                    { 2, "Ivan Ivanov", "The second best course in here, trust", 155, "~/img/test2.jpg", "Course no2", 1 },
                    { 3, "Ivan Ivanov", "The third best course in here, trust", 198, "https://st.depositphotos.com/1075946/1820/i/450/depositphotos_18206843-stock-photo-group-of-young-in-training.jpg", "Course no3", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Photo", "Role" },
                values: new object[,]
                {
                    { 1, "Ivan_Ivanov@abv.bg", "Ivan", "Ivanov", "123", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.photocdn.pt%2Fimages%2Farticles%2F2019%2F08%2F07%2Fimages%2Farticles%2F2019%2F07%2F31%2Fbest_linkedin_photos.jpg&f=1&nofb=1", 0 },
                    { 2, "Georgi_georgiev@abv.bg", "Georgi", "Geirgiev", "1223", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.BxO--7Fr7JssN9Tj9wII_QHaLG%26pid%3DApi&f=1", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Content", "CourseId", "EndDate", "LastEdit", "Order", "SectionId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Description of the first test section", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, "First test section" },
                    { 2, "Description of the second test section", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, "Second test section" },
                    { 3, "Description of the third test section", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, "Third test section" }
                });

            migrationBuilder.InsertData(
                table: "UserCourse",
                columns: new[] { "CourseId", "UserId", "Id" },
                values: new object[] { 2, 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionId",
                table: "Sections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_UserId",
                table: "UserCourse",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
