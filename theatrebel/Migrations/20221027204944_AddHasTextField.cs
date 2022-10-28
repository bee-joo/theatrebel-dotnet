using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theatrebel.Migrations
{
    public partial class AddHasTextField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_text",
                table: "plays",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_text",
                table: "plays");
        }
    }
}
