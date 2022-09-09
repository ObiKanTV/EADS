using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADS.RazorDemo.Migrations
{
    public partial class docreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "DemoObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "DemoObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "DemoObjects");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "DemoObjects");
        }
    }
}
