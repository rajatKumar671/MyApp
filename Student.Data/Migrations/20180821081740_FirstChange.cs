using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class FirstChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseDuration",
                table: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompeletionDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompeletionDate",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "CourseDuration",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }
    }
}
