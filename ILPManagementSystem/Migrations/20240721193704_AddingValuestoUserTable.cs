using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddingValuestoUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailId", "FirstName", "Gender", "IsActive", "LastName", "MobileNumber", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "amal_admin@sreegcloudgmail.onmicrosoft.com", "Amal", 0, true, "Admin", "1234567890", "Gowo690819", 1 },
                    { 2, "devipriya_admin@sreegcloudgmail.onmicrosoft.com", "Devipriya", 1, true, "Admin", "1234567891", "Vajo021247", 1 },
                    { 3, "suneesh.thampi@sreegcloudgmail.onmicrosoft.com", "Suneesh", 0, true, "Thampi", "1234567892", "Huna544047", 2 },
                    { 4, "lekshmi.a@sreegcloudgmail.onmicrosoft.com", "Lekshmi", 1, true, "A", "1234567893", "Quwu856933", 2 },
                    { 5, "jisna.george@sreegcloudgmail.onmicrosoft.com", "Jisna", 1, true, "George", "1234567894", "Koso191442", 3 },
                    { 6, "thulasi.k@sreegcloudgmail.onmicrosoft.com", "Thulasi", 1, true, "K", "1234567895", "Toqo391712", 3 },
                    { 7, "dharsan.sajeev@sreegcloudgmail.onmicrosoft.com", "Dharsan", 0, true, "Sajeev", "1234567896", "Zuja977409", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
