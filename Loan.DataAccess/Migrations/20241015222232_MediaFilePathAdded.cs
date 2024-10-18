using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MediaFilePathAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("52e979da-b447-446c-88ba-f062d508b8a3"), new Guid("b178df9b-7669-4a9c-ab4b-b96fbbb55ccd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52e979da-b447-446c-88ba-f062d508b8a3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b178df9b-7669-4a9c-ab4b-b96fbbb55ccd"));

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Medias");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Medias",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("52e979da-b447-446c-88ba-f062d508b8a3"), "bb342a96-3c05-49af-9f1f-918c411d2e1b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b178df9b-7669-4a9c-ab4b-b96fbbb55ccd"), 0, "1decccda-f72e-40b1-a970-221df14af2e4", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEGkn7GBWVsMprx7G8s++9GtptEAPXdAYyDd/LhyXSOP/Ek0tKQYJxdaOc+yjce+pwg==", null, false, "b68b8d1a-76c2-4f0a-aa79-882903fe845a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("52e979da-b447-446c-88ba-f062d508b8a3"), new Guid("b178df9b-7669-4a9c-ab4b-b96fbbb55ccd") });
        }
    }
}
