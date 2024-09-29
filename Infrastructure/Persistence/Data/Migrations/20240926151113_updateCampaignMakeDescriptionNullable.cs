using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCampaignMakeDescriptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Campaign",
                type: "character varying(16384)",
                maxLength: 16384,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(16384)",
                oldMaxLength: 16384);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Campaign",
                type: "character varying(16384)",
                maxLength: 16384,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(16384)",
                oldMaxLength: 16384,
                oldNullable: true);
        }
    }
}
