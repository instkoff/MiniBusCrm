using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Buses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Buses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Drivers",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Drivers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Passangers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Passangers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Routes",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RouteName = table.Column<string>(nullable: true),
                    ArrivalCity = table.Column<string>(nullable: true),
                    DepartureCity = table.Column<string>(nullable: true),
                    DriverId = table.Column<Guid>(nullable: true),
                    BusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        "FK_Routes_Buses_BusId",
                        x => x.BusId,
                        "Buses",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Routes_Drivers_DriverId",
                        x => x.DriverId,
                        "Drivers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Orders",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    RouteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        "FK_Orders_Routes_RouteId",
                        x => x.RouteId,
                        "Routes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Tickets",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PassengerId = table.Column<Guid>(nullable: true),
                    Seat = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>("money", nullable: false),
                    IsBaggage = table.Column<bool>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RouteId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        "FK_Tickets_Orders_OrderId",
                        x => x.OrderId,
                        "Orders",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Tickets_Passangers_PassengerId",
                        x => x.PassengerId,
                        "Passangers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Tickets_Routes_RouteId",
                        x => x.RouteId,
                        "Routes",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Orders_RouteId",
                "Orders",
                "RouteId");

            migrationBuilder.CreateIndex(
                "IX_Routes_BusId",
                "Routes",
                "BusId");

            migrationBuilder.CreateIndex(
                "IX_Routes_DriverId",
                "Routes",
                "DriverId");

            migrationBuilder.CreateIndex(
                "IX_Tickets_OrderId",
                "Tickets",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_Tickets_PassengerId",
                "Tickets",
                "PassengerId");

            migrationBuilder.CreateIndex(
                "IX_Tickets_RouteId",
                "Tickets",
                "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Tickets");

            migrationBuilder.DropTable(
                "Orders");

            migrationBuilder.DropTable(
                "Passangers");

            migrationBuilder.DropTable(
                "Routes");

            migrationBuilder.DropTable(
                "Buses");

            migrationBuilder.DropTable(
                "Drivers");
        }
    }
}