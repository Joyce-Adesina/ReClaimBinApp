using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReClaimBinApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "6dc1116b-a545-4380-9287-caddb8fbb8ce", null, "Supplier", "SUPPLIER" },
                    { "8bfab4a3-9139-49d4-a0f8-a287d9dafc28", null, "Manufacturer", "MANUFACTURER" },
                    { "e5be2d5f-0d81-414f-a614-246cfc421bee", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dc1116b-a545-4380-9287-caddb8fbb8ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bfab4a3-9139-49d4-a0f8-a287d9dafc28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5be2d5f-0d81-414f-a614-246cfc421bee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20faf311-74be-4a1c-b65e-4502522fe004", null, "Admin", "ADMIN" },
                    { "8cb37d0f-7592-4276-9822-300905a9c1e6", null, "User", "USER" }
                });
        }
    }
}
