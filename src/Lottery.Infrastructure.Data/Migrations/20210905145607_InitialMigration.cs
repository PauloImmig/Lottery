using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Mail = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Action = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Entries = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Details = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Region = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Country = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Facebook = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Instagram = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Twitter = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Youtube = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
