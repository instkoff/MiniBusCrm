using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class FixDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoumentSerialNumber",
                table: "BusDrivers");

            migrationBuilder.AddColumn<string>(
                name: "DocumentSerialNumber",
                table: "BusDrivers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentSerialNumber",
                table: "BusDrivers");

            migrationBuilder.AddColumn<string>(
                name: "DoumentSerialNumber",
                table: "BusDrivers",
                type: "text",
                nullable: true);
        }
    }
}
