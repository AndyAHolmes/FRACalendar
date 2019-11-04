using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FRACalendar.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    ContactEmailAddress = table.Column<string>(maxLength: 300, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 200, nullable: true),
                    Town = table.Column<string>(maxLength: 100, nullable: true),
                    County = table.Column<string>(maxLength: 100, nullable: true),
                    Postcode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    RaceDistanceInMiles = table.Column<decimal>(nullable: false),
                    RaceClimbInFeet = table.Column<decimal>(nullable: false),
                    PrimaryRaceContactId = table.Column<int>(nullable: true),
                    RaceDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Race_RaceContact_PrimaryRaceContactId",
                        column: x => x.PrimaryRaceContactId,
                        principalTable: "RaceContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_PrimaryRaceContactId",
                table: "Race",
                column: "PrimaryRaceContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "RaceContact");
        }
    }
}
