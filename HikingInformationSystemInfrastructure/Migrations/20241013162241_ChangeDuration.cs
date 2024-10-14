using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikingInformationSystemInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDuration",
                table: "Hikes");

            migrationBuilder.AddColumn<double>(
                name: "TotalDurationInMinutes",
                table: "Hikes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDurationInMinutes",
                table: "Hikes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalDuration",
                table: "Hikes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
