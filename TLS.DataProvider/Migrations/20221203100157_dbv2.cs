using Microsoft.EntityFrameworkCore.Migrations;

namespace TLS.DataProvider.Migrations
{
    public partial class dbv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
