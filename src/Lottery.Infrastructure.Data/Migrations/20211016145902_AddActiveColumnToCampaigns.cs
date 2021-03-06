using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.Infrastructure.Data.Migrations
{
    public partial class AddActiveColumnToCampaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Campaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Campaigns");
        }
    }
}
