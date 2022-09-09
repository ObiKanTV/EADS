using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADS.Infrastructure.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncryptionValues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassIterations = table.Column<int>(type: "int", nullable: false),
                    KeySize = table.Column<int>(type: "int", nullable: false),
                    InitVector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaltValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptionValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemoPresentationEncObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptionValueId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoPresentationEncObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemoPresentationEncObjects_EncryptionValues_EncryptionValueId",
                        column: x => x.EncryptionValueId,
                        principalTable: "EncryptionValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EncObjectData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptionValueId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncObjectData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncObjectData_EncryptionValues_EncryptionValueId",
                        column: x => x.EncryptionValueId,
                        principalTable: "EncryptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncStringData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptionValueId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncStringData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncStringData_EncryptionValues_EncryptionValueId",
                        column: x => x.EncryptionValueId,
                        principalTable: "EncryptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemoPresentationEncObjects_EncryptionValueId",
                table: "DemoPresentationEncObjects",
                column: "EncryptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_EncObjectData_EncryptionValueId",
                table: "EncObjectData",
                column: "EncryptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_EncStringData_EncryptionValueId",
                table: "EncStringData",
                column: "EncryptionValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoPresentationEncObjects");

            migrationBuilder.DropTable(
                name: "EncObjectData");

            migrationBuilder.DropTable(
                name: "EncStringData");

            migrationBuilder.DropTable(
                name: "EncryptionValues");
        }
    }
}
