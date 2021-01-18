using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcViewModels.Migrations
{
    public partial class JoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguagesList_LanguagesList_LanguageId",
                table: "LanguagesList");

            migrationBuilder.DropIndex(
                name: "IX_LanguagesList_LanguageId",
                table: "LanguagesList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "LanguagesList");

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => new { x.PersonId, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_PersonLanguages_LanguagesList_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "LanguagesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_PeopleList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PeopleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageID",
                table: "PersonLanguages",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "LanguagesList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguagesList_LanguageId",
                table: "LanguagesList",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagesList_LanguagesList_LanguageId",
                table: "LanguagesList",
                column: "LanguageId",
                principalTable: "LanguagesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
