using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikingInformationSystemInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTimeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Routes");

            migrationBuilder.AddColumn<double>(
                name: "DurationInMinutes",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Routes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
