using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPM.API.Migrations
{
    public partial class InitDbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    NumberOfUsers = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Biologicaltk@gmail.com", "Pass1", "Admin", "Tshoki" },
                    { 2, "gao@gmail.com", "Pass2", "Admin", "Gao" },
                    { 3, "titik@yahoo.com", "Pass3", "User", "Titi" }
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ID", "ClientName", "CreatedOn", "Location", "NumberOfUsers" },
                values: new object[,]
                {
                    { 1, "AdaptIT_JHB", new DateTime(2023, 2, 1, 17, 40, 42, 353, DateTimeKind.Local).AddTicks(3430), "Gauteng", 8 },
                    { 2, "AdaptIT_CA", new DateTime(2023, 2, 1, 17, 40, 42, 356, DateTimeKind.Local).AddTicks(8177), "Eastern Cape", 1 },
                    { 3, "AdaptIT_KZN", new DateTime(2023, 2, 1, 17, 40, 42, 356, DateTimeKind.Local).AddTicks(8564), "Durban", 4 },
                    { 4, "TG-Tech", new DateTime(2023, 2, 1, 17, 40, 42, 356, DateTimeKind.Local).AddTicks(8622), "Gauteng", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
