using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.Infrastructure.Data.Migrations
{
    public partial class AddParticipantsCampaignFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                table: "Participants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "LuckyNumber",
                table: "Participants",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CampaignId",
                table: "Participants",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Campaigns_CampaignId",
                table: "Participants",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Campaigns_CampaignId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_CampaignId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "LuckyNumber",
                table: "Participants");
        }
    }
}
