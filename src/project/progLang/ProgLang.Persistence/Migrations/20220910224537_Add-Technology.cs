using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgLang.Persistence.Migrations
{
    public partial class AddTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technology_ProgrammingLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "ProgrammingLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technology",
                columns: new[] { "Id", "Description", "ImageUrl", "LanguageId", "Name" },
                values: new object[] { 1, "Description", "ImageURL", 1, "WPF" });

            migrationBuilder.InsertData(
                table: "Technology",
                columns: new[] { "Id", "Description", "ImageUrl", "LanguageId", "Name" },
                values: new object[] { 2, "Descriotion", "ImageURL", 1, "ASPNET" });

            migrationBuilder.CreateIndex(
                name: "IX_Technology_LanguageId",
                table: "Technology",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technology");
        }
    }
}
