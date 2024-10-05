using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPrivateToNonPlayerCharacterAndMonster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPrivate",
                table: "Character",
                newName: "NonPlayerCharacter_IsPrivate");

            migrationBuilder.AddColumn<bool>(
                name: "Monster_IsPrivate",
                table: "Character",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monster_IsPrivate",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "NonPlayerCharacter_IsPrivate",
                table: "Character",
                newName: "IsPrivate");
        }
    }
}
