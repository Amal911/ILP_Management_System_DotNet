using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class phaseTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhaseDuration",
                table: "Phases",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhaseDuration",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhaseDuration",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhaseDuration",
                value: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhaseDuration",
                table: "Phases");
        }
    }
}
