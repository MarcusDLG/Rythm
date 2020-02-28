using Microsoft.EntityFrameworkCore.Migrations;

namespace Rythm.Migrations
{
    public partial class FixedBandTableToHaveName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bands");
        }
    }
}
