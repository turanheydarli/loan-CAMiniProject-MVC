using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EntityConfigurationInitialized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58d2937f-97cc-4d2d-959a-c2f9708d9d7c", "70a8d5a3-58ea-4389-8330-d6571770ac6c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91f3da88-5878-4b83-9acc-c5ac0173ca77", 0, "5f8c168a-07db-4235-8a6e-c981fe84b954", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFGd19faQbxdJGPPz1bBH4Ym3JzXOOwVm3ygGzACWXa/QFeXn90ZE3vqRt/cJ4JnAQ==", null, false, "a64b4976-8e24-49f0-8e77-efd04b636aba", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58d2937f-97cc-4d2d-959a-c2f9708d9d7c", "91f3da88-5878-4b83-9acc-c5ac0173ca77" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58d2937f-97cc-4d2d-959a-c2f9708d9d7c", "91f3da88-5878-4b83-9acc-c5ac0173ca77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58d2937f-97cc-4d2d-959a-c2f9708d9d7c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91f3da88-5878-4b83-9acc-c5ac0173ca77");
        }
    }
}
