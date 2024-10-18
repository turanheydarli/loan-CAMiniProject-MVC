using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BranchAddressConfigurationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_AddressId",
                table: "Branches");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0f715fef-d3da-4f8a-9854-055e25e041bc"), new Guid("312f4d62-8c09-4173-b469-514f59cf2b77") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0f715fef-d3da-4f8a-9854-055e25e041bc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("312f4d62-8c09-4173-b469-514f59cf2b77"));

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ec7b8465-68ea-4eed-8089-ec4481334749"), "dca361b1-437b-43e6-8827-83f0243c3cf9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f613f61e-22f2-4949-9d3b-360b7acb034b"), 0, "81e0b078-cd7f-4a46-9210-53199e09aa8a", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEOoyIVNSF4vv+HCZYEoO+UFS6ilLTSaSBOHWjbG0LzHAFO5HylmYjMMefvxMnMTc1Q==", null, false, "6dacb27b-026d-4531-bbeb-8c81d5105a92", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ec7b8465-68ea-4eed-8089-ec4481334749"), new Guid("f613f61e-22f2-4949-9d3b-360b7acb034b") });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BranchId",
                table: "Addresses",
                column: "BranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Branches_BranchId",
                table: "Addresses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Branches_BranchId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BranchId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ec7b8465-68ea-4eed-8089-ec4481334749"), new Guid("f613f61e-22f2-4949-9d3b-360b7acb034b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec7b8465-68ea-4eed-8089-ec4481334749"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f613f61e-22f2-4949-9d3b-360b7acb034b"));

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0f715fef-d3da-4f8a-9854-055e25e041bc"), "c2363cba-9227-49c6-879c-bfd09f80facc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("312f4d62-8c09-4173-b469-514f59cf2b77"), 0, "6e03a765-4ff1-4ee6-a056-028907e64f5c", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEMbli0tzfknzxkD6J/dcYBN9FfgBRHG4/GX5vVEzPlkBC0SKJwFIRp98KRxSxxxbLg==", null, false, "199909ab-bf26-4895-ac17-62e6dbfad9de", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("0f715fef-d3da-4f8a-9854-055e25e041bc"), new Guid("312f4d62-8c09-4173-b469-514f59cf2b77") });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_AddressId",
                table: "Branches",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Addresses_AddressId",
                table: "Branches",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
