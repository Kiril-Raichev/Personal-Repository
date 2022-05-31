using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum1.Migrations
{
    public partial class photoDataField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "fileData",
                table: "User",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileData",
                table: "User");
        }
    }
}
