using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcViewModels.Migrations
{
    public partial class AddedCountrysToPersonCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "PeopleList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_CountryId",
                table: "PeopleList",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_CountrieList_CountryId",
                table: "PeopleList",
                column: "CountryId",
                principalTable: "CountrieList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_CountrieList_CountryId",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_CountryId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "PeopleList");
        }
    }
}
