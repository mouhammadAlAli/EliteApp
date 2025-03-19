using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddPracticesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PracticeId",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Practices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Practices_PracticeId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Practices");

            migrationBuilder.DropIndex(
                name: "IX_Users_PracticeId",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PracticeId",
                schema: "Identity",
                table: "Users");
        }
    }
}
