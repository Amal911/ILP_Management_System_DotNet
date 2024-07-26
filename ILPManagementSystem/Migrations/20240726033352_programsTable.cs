using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class programsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_programs_ProgramId",
                table: "Batchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_programs",
                table: "programs");

            migrationBuilder.RenameTable(
                name: "programs",
                newName: "Programs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Programs_ProgramId",
                table: "Batchs",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Programs_ProgramId",
                table: "Batchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "programs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_programs",
                table: "programs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_programs_ProgramId",
                table: "Batchs",
                column: "ProgramId",
                principalTable: "programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
