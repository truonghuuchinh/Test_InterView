using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_InterView.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserPhone = table.Column<int>(nullable: false),
                    UserBirthday = table.Column<DateTime>(nullable: false),
                    UserGender = table.Column<bool>(nullable: false),
                    UserPassword = table.Column<string>(nullable: false),
                    UserCreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
