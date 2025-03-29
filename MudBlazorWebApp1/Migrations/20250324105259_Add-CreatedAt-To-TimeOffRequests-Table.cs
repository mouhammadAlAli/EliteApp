using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtToTimeOffRequestsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_timeOffRequests_Users_UserId",
                table: "timeOffRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_timeOffRequests",
                table: "timeOffRequests");

            migrationBuilder.RenameTable(
                name: "timeOffRequests",
                newName: "TimeOffRequests");

            migrationBuilder.RenameIndex(
                name: "IX_timeOffRequests_UserId",
                table: "TimeOffRequests",
                newName: "IX_TimeOffRequests_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TimeOffRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeOffRequests",
                table: "TimeOffRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequests_Users_UserId",
                table: "TimeOffRequests",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequests_Users_UserId",
                table: "TimeOffRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeOffRequests",
                table: "TimeOffRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TimeOffRequests");

            migrationBuilder.RenameTable(
                name: "TimeOffRequests",
                newName: "timeOffRequests");

            migrationBuilder.RenameIndex(
                name: "IX_TimeOffRequests_UserId",
                table: "timeOffRequests",
                newName: "IX_timeOffRequests_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_timeOffRequests",
                table: "timeOffRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_timeOffRequests_Users_UserId",
                table: "timeOffRequests",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
