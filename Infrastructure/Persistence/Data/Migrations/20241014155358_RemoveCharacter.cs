using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    Alignment = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false),
                    CharacterType = table.Column<int>(type: "integer", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(32768)", maxLength: 32768, nullable: true),
                    HitPoints = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Monster_CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    ChallengeRating = table.Column<int>(type: "integer", nullable: true),
                    Monster_IsPrivate = table.Column<bool>(type: "boolean", nullable: true),
                    MonsterType = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    NonPlayerCharacter_CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    NonPlayerCharacter_IsPrivate = table.Column<bool>(type: "boolean", nullable: true),
                    PlayerCharacter_CampaignId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Campaign_Monster_CampaignId",
                        column: x => x.Monster_CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Campaign_NonPlayerCharacter_CampaignId",
                        column: x => x.NonPlayerCharacter_CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Campaign_PlayerCharacter_CampaignId",
                        column: x => x.PlayerCharacter_CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_CreatedById",
                table: "Character",
                column: "CreatedById");

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
        }
    }
}
