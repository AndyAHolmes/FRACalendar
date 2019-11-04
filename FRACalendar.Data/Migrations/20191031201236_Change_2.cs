using Microsoft.EntityFrameworkCore.Migrations;

namespace FRACalendar.Data.Migrations
{
    public partial class Change_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FRAInsured",
                table: "Race",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FRAInsured",
                table: "Race");
        }
    }
}
