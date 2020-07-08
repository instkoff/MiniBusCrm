using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
