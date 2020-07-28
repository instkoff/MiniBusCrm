using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class JourneyRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "JourneyId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_JourneyId",
                table: "Tickets",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_JourneyId",
                table: "Tickets",
                column: "JourneyId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Orders_JourneyId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_JourneyId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "JourneyId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Tickets",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Orders_OrderId",
                table: "Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
