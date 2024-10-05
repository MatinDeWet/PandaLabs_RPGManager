using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalPropertiesForCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alignment",
                table: "Character",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeRating",
                table: "Character",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonsterType",
                table: "Character",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Monster_CampaignId",
                table: "Character",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NonPlayerCharacter_CampaignId",
                table: "Character",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerCharacter_CampaignId",
                table: "Character",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Character",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_Monster_CampaignId",
                table: "Character",
                column: "Monster_CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_NonPlayerCharacter_CampaignId",
                table: "Character",
                column: "NonPlayerCharacter_CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlayerCharacter_CampaignId",
                table: "Character",
                column: "PlayerCharacter_CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Campaign_Monster_CampaignId",
                table: "Character",
                column: "Monster_CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Campaign_NonPlayerCharacter_CampaignId",
                table: "Character",
                column: "NonPlayerCharacter_CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Campaign_PlayerCharacter_CampaignId",
                table: "Character",
                column: "PlayerCharacter_CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Campaign_Monster_CampaignId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Campaign_NonPlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Campaign_PlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_Monster_CampaignId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_NonPlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_PlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "ChallengeRating",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "MonsterType",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Monster_CampaignId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "NonPlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "PlayerCharacter_CampaignId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Character");
        }
    }
}
