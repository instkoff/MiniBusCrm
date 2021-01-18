using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    public partial class AddUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "FirstName", "IsActive", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("78993485-e953-4dbb-b939-fe9e684e6530"), new DateTime(2021, 1, 18, 12, 19, 39, 995, DateTimeKind.Local).AddTicks(6738), "Admin", true, "Admin", "10.ioFD9w0SjwRA4DkHX0tHqg==.yLUtO8z+E0XrpTcC51+G8mfZm3dTR37dbtNYPGCt3e8=", "Admin", "admin" },
                    { new Guid("f5802476-b465-443b-af72-c954a97c6f6c"), new DateTime(2021, 1, 18, 12, 19, 39, 995, DateTimeKind.Local).AddTicks(9539), "Operator", true, "Operator", "10.CklkfSFyQ8TnMgaToPThNQ==.Qbg+8BgQz1odxkIgq0IDsxyTgkr/2OsYJhDtMIU6WyQ=", "Operator", "oper" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
