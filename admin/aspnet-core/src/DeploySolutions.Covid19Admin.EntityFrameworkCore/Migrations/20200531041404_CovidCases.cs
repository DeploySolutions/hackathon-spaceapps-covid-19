using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeploySolutions.Covid19Admin.Migrations
{
    public partial class CovidCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CovidCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placename = table.Column<string>(maxLength: 256, nullable: false),
                    CaseOutcome = table.Column<string>(maxLength: 256, nullable: false),
                    Lat = table.Column<decimal>(nullable: false),
                    Long = table.Column<decimal>(nullable: false),
                    PatientAge = table.Column<decimal>(nullable: false),
                    PatientGender = table.Column<string>(nullable: true),
                    LocationType = table.Column<string>(nullable: true),
                    CaseRecordedDate = table.Column<DateTime>(maxLength: 65536, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidCases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidCases");
        }
    }
}
