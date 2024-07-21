using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class batchTableColumnRename2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_BatchTypes_batchTypeId",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "batchTypeId",
                table: "Batchs",
                newName: "BatchTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Batchs_batchTypeId",
                table: "Batchs",
                newName: "IX_Batchs_BatchTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_BatchTypes_BatchTypeId",
                table: "Batchs",
                column: "BatchTypeId",
                principalTable: "BatchTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_BatchTypes_BatchTypeId",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "BatchTypeId",
                table: "Batchs",
                newName: "batchTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Batchs_BatchTypeId",
                table: "Batchs",
                newName: "IX_Batchs_batchTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_BatchTypes_batchTypeId",
                table: "Batchs",
                column: "batchTypeId",
                principalTable: "BatchTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
