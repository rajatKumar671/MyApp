using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class SecondChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Students");
        }
    }
}
