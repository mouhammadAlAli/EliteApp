using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class FixUserPracticeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Practices_PracticeId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PracticeId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PracticeId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "PracticeGuid",
                schema: "Identity",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PracticeGuid",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "PracticeId",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PracticeId",
                schema: "Identity",
                table: "Users",
                column: "PracticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Practices_PracticeId",
                schema: "Identity",
                table: "Users",
                column: "PracticeId",
                principalTable: "Practices",
                principalColumn: "Id");
        }
    }
}
