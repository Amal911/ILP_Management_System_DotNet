using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class locationTableUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Batchs_LocationId",
                table: "Batchs",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Locations_LocationId",
                table: "Batchs",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Locations_LocationId",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_LocationId",
                table: "Batchs");
        }
    }
}
