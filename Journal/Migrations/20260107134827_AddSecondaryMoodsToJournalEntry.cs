using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondaryMoodsToJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondaryMood1",
                table: "Journals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMood2",
                table: "Journals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryMood1",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "SecondaryMood2",
                table: "Journals");
        }
    }
}
