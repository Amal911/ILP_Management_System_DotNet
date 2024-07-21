using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class DataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "Id", "AssessmentTypeName" },
                values: new object[,]
                {
                    { 1, "Daily Assessment" },
                    { 2, "Live Assessment" },
                    { 3, "Case Study" }
                });

            migrationBuilder.InsertData(
                table: "BatchTypes",
                columns: new[] { "Id", "BatchTypeName" },
                values: new object[,]
                {
                    { 1, "Technical" },
                    { 2, "BA" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Trivandrum" },
                    { 2, "Kochi" }
                });

            migrationBuilder.InsertData(
                table: "Phases",
                columns: new[] { "Id", "PhaseName" },
                values: new object[,]
                {
                    { 1, "E-Learning" },
                    { 2, "Tech Fundamentals" },
                    { 3, "Business Orientation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssessmentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BatchTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BatchTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phases",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
