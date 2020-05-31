using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeploySolutions.Covid19Admin.Migrations
{
    public partial class EnvironmentFactors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationType",
                table: "CovidCases",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EnvironmentFactors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placename = table.Column<string>(maxLength: 256, nullable: false),
                    Indicator = table.Column<string>(maxLength: 256, nullable: false),
                    ValueRaw = table.Column<string>(maxLength: 256, nullable: false),
                    ValueDiscrete = table.Column<string>(maxLength: 256, nullable: false),
                    Lat = table.Column<decimal>(nullable: false),
                    Long = table.Column<decimal>(nullable: false),
                    LocationType = table.Column<string>(maxLength: 256, nullable: true),
                    MeasurementRecordedDate = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentFactors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentFactors");

            migrationBuilder.AlterColumn<string>(
                name: "LocationType",
                table: "CovidCases",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
