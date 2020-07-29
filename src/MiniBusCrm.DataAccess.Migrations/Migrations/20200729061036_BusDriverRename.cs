using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class BusDriverRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Drivers_DriverId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DriverId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Routes");

            migrationBuilder.AddColumn<Guid>(
                name: "BusDriverId",
                table: "Routes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusDrivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    DoumentSerialNumber = table.Column<string>(nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDrivers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BusDriverId",
                table: "Routes",
                column: "BusDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_BusDrivers_BusDriverId",
                table: "Routes",
                column: "BusDriverId",
                principalTable: "BusDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_BusDrivers_BusDriverId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "BusDrivers");

            migrationBuilder.DropIndex(
                name: "IX_Routes_BusDriverId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "BusDriverId",
                table: "Routes");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Routes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DocumentNumber = table.Column<string>(type: "text", nullable: true),
                    DoumentSerialNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DriverId",
                table: "Routes",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Drivers_DriverId",
                table: "Routes",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
