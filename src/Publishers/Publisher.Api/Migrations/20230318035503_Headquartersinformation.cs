using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Publisher.Api.Migrations
{
    /// <inheritdoc />
    public partial class Headquartersinformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadquartersLocation",
                table: "Publishers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Publishers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadquartersLocation",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Publishers");
        }
    }
}
