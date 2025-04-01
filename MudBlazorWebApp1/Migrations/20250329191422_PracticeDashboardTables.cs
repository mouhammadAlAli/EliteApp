using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class PracticeDashboardTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<long>(type: "bigint", nullable: false),
                    PatientGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentConfirmationStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentConfirmationStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentGuid);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAccountingErrors",
                columns: table => new
                {
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimtransactionTypeErrorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTransactionTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ClaimAccountings",
                columns: table => new
                {
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTransactionId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTransactionTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTransactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncounterProcedureId = table.Column<long>(type: "bigint", nullable: true),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EncounterProcedureId = table.Column<long>(type: "bigint", nullable: true),
                    PatientGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTransactions",
                columns: table => new
                {
                    ClaimTransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTransactionTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTransactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTransactions", x => x.ClaimTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorGuid);
                });

            migrationBuilder.CreateTable(
                name: "EncounterProcedures",
                columns: table => new
                {
                    EncounterProcedureId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncounterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncounterProcedures", x => x.EncounterProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "Encounters",
                columns: table => new
                {
                    EncounterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EncounterId = table.Column<long>(type: "bigint", nullable: false),
                    AppointmentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProviderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceLocationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfService = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EncounterStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounters", x => x.EncounterGuid);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientGuid);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocations",
                columns: table => new
                {
                    ServiceLocationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceLocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocations", x => x.ServiceLocationGuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ClaimAccountingErrors");

            migrationBuilder.DropTable(
                name: "ClaimAccountings");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ClaimTransactions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "EncounterProcedures");

            migrationBuilder.DropTable(
                name: "Encounters");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "ServiceLocations");
        }
    }
}
