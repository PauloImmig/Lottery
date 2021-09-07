using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.Infrastructure.Data.Migrations
{
    public partial class AddCampaing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Period_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignEmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Placeholders = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignEmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignEmailTemplates_Campaigns_Id",
                        column: x => x.Id,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignEmailTemplates");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
