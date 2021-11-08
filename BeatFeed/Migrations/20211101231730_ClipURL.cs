using Microsoft.EntityFrameworkCore.Migrations;

namespace BeatFeed.Migrations
{
    public partial class ClipURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClipURL",
                table: "Song",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClipURL",
                table: "Song");
        }
    }
}
