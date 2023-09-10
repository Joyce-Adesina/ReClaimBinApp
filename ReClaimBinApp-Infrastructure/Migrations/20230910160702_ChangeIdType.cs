using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReClaimBinApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23a1a70c-d646-4c72-b23b-8b74442d7b0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0317472-f7e3-4db6-8af4-9d2d40c45e99");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "suppliers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b1a3675-af03-463e-a796-7683089e96e6", null, "Admin", "ADMIN" },
                    { "c4cf37e8-1609-429f-949b-ca839911909a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b1a3675-af03-463e-a796-7683089e96e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4cf37e8-1609-429f-949b-ca839911909a");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "suppliers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23a1a70c-d646-4c72-b23b-8b74442d7b0f", null, "Admin", "ADMIN" },
                    { "a0317472-f7e3-4db6-8af4-9d2d40c45e99", null, "User", "USER" }
                });
        }
    }
}
