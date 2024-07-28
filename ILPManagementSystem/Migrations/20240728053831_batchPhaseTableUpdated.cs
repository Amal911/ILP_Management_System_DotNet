using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class batchPhaseTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "BatchPhase");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BatchPhase",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BatchPhase");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "BatchPhase",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
