using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoApi.Migrations
{
    public partial class InstructionPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegoSetInstructionsPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PageNumber = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    LegoSetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoSetInstructionsPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegoSetInstructionsPages_LegoSets_LegoSetId",
                        column: x => x.LegoSetId,
                        principalTable: "LegoSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegoSetInstructionsPages_LegoSetId",
                table: "LegoSetInstructionsPages",
                column: "LegoSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegoSetInstructionsPages");
        }
    }
}
