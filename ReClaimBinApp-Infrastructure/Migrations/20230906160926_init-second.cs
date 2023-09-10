using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReClaimBinApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initsecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "437372c5-7ac1-47e5-80ad-3e6fab981c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b97bedb-6c94-48d1-be74-608f0de22e10");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "manufacturers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "259a4053-12e6-4b5c-82ac-ac44bb7258e7", null, "Admin", "ADMIN" },
                    { "cb7ec323-47ee-48dc-8ae0-0f28940c9127", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "259a4053-12e6-4b5c-82ac-ac44bb7258e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb7ec323-47ee-48dc-8ae0-0f28940c9127");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "manufacturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "437372c5-7ac1-47e5-80ad-3e6fab981c27", null, "Admin", "ADMIN" },
                    { "6b97bedb-6c94-48d1-be74-608f0de22e10", null, "User", "USER" }
                });
        }
    }
}
