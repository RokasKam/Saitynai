using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HikingInformationSystemInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenUserAndHike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Hikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Hikes_CreatorId",
                table: "Hikes",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hikes_AspNetUsers_CreatorId",
                table: "Hikes",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hikes_AspNetUsers_CreatorId",
                table: "Hikes");

            migrationBuilder.DropIndex(
                name: "IX_Hikes_CreatorId",
                table: "Hikes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Hikes");
        }
    }
}
