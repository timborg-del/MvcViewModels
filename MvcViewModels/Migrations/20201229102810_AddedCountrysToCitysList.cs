using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcViewModels.Migrations
{
    public partial class AddedCountrysToCitysList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityList_CountrieList_CountryId",
                table: "CityList");

            migrationBuilder.DropIndex(
                name: "IX_CityList_CountryId",
                table: "CityList");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CityList");

            migrationBuilder.AddColumn<int>(
                name: "CountriesId",
                table: "CityList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityList_CountriesId",
                table: "CityList",
                column: "CountriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityList_CountrieList_CountriesId",
                table: "CityList",
                column: "CountriesId",
                principalTable: "CountrieList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityList_CountrieList_CountriesId",
                table: "CityList");

            migrationBuilder.DropIndex(
                name: "IX_CityList_CountriesId",
                table: "CityList");

            migrationBuilder.DropColumn(
                name: "CountriesId",
                table: "CityList");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "CityList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityList_CountryId",
                table: "CityList",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityList_CountrieList_CountryId",
                table: "CityList",
                column: "CountryId",
                principalTable: "CountrieList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
