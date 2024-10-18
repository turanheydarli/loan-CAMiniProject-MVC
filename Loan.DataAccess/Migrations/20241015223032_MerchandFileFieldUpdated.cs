using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MerchandFileFieldUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("038cb73f-45bf-4cd8-94dc-88ca3d9fb1bd"), new Guid("8771daca-718b-4491-88fb-ba6645b8e89f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("038cb73f-45bf-4cd8-94dc-88ca3d9fb1bd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8771daca-718b-4491-88fb-ba6645b8e89f"));

            migrationBuilder.RenameColumn(
                name: "BusinessLicensePath",
                table: "Merchants",
                newName: "BusinessLicenseFileId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "BusinessLicenseFileId",
                table: "Merchants",
                newName: "BusinessLicensePath");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("038cb73f-45bf-4cd8-94dc-88ca3d9fb1bd"), "58feb4f8-4e26-460c-887e-135b35b360c2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8771daca-718b-4491-88fb-ba6645b8e89f"), 0, "49b30fd0-17dc-483b-a735-b4101f06c66b", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEPcQ0OMV7CE2ov27jkE7GbmzJsj62Qr9V7ExMhtVTKdEafwZu49gp1TRr4ld2ohOiQ==", null, false, "ed991778-abd6-4af3-9db9-647451a37cd2", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("038cb73f-45bf-4cd8-94dc-88ca3d9fb1bd"), new Guid("8771daca-718b-4491-88fb-ba6645b8e89f") });
        }
    }
}
