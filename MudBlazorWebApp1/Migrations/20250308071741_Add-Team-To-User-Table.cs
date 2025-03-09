using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                schema: "Identity",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                schema: "Identity",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
