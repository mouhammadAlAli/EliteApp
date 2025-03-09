using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToTeamsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teams");
        }
    }
}
