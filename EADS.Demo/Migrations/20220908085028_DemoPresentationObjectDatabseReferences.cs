using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADS.Demo.Migrations
{
    public partial class DemoPresentationObjectDatabseReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemoPresentationObject",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoPresentationObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemoPresentationObjectDatabaseReferences",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataStoreKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoPresentationObjectDatabaseReferences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoPresentationObject");

            migrationBuilder.DropTable(
                name: "DemoPresentationObjectDatabaseReferences");
        }
    }
}
