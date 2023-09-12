using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReClaimBinApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d1e4b5-27db-4cd6-bb05-7fcaaae47233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac67d1a0-d637-438d-a914-14e39877798c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20faf311-74be-4a1c-b65e-4502522fe004", null, "Admin", "ADMIN" },
                    { "8cb37d0f-7592-4276-9822-300905a9c1e6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20faf311-74be-4a1c-b65e-4502522fe004");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cb37d0f-7592-4276-9822-300905a9c1e6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77d1e4b5-27db-4cd6-bb05-7fcaaae47233", null, "User", "USER" },
                    { "ac67d1a0-d637-438d-a914-14e39877798c", null, "Admin", "ADMIN" }
                });
        }
    }
}
