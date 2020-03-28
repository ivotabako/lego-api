using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoApi.Migrations
{
    public partial class AddLegoNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdNumber",
                table: "LegoSets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "LegoSets");
        }
    }
}
