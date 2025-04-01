using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class PracticeDashboardPaymentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentClaims",
                columns: table => new
                {
                    EncounterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceEncounterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentClaims");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
