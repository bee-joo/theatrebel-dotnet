using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theatrebel.Migrations
{
    public partial class AddTextFieldToPlay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "plays",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "plays");
        }
    }
}
