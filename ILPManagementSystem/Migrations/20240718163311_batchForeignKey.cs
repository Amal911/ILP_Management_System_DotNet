using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class batchForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Batchs",
                newName: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_LocationId1",
                table: "Batchs",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Locations_LocationId1",
                table: "Batchs",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Locations_LocationId1",
                table: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_LocationId1",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "LocationId1",
                table: "Batchs",
                newName: "LocationId");
        }
    }
}
