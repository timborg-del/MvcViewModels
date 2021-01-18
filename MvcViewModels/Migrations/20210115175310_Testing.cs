using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcViewModels.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PeopleList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "PeopleList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_LanguagesList_LanguageId",
                table: "PeopleList",
                column: "LanguageId",
                principalTable: "LanguagesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_LanguagesList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "PeopleList");
        }
    }
}
