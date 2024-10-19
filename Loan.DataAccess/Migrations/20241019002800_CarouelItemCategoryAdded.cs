using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CarouelItemCategoryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7454e9c8-d3ef-47b3-9ef4-588484808b55"), new Guid("3046b59f-8f49-4190-9202-09f9f2a61130") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7454e9c8-d3ef-47b3-9ef4-588484808b55"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3046b59f-8f49-4190-9202-09f9f2a61130"));

            migrationBuilder.DropColumn(
                name: "ImagesIds",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("71e11f91-5e42-469d-a395-01b5b826b883"), "1133a237-bf63-4c6d-9b82-d57345c9a8b4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9b14c6c1-9d29-4aac-b73f-60a849159c82"), 0, "7e40fdb3-c584-432e-b4dd-8856ad2b3e0f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFg4VHQczu/QfdqpWYXovuuCqQRqjGe7v/CFE27nDrY4hurXra2nY0ZMAPQBb+akKw==", null, false, "1e6e71d0-bb1f-4a99-b96c-2686646085e3", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("71e11f91-5e42-469d-a395-01b5b826b883"), new Guid("9b14c6c1-9d29-4aac-b73f-60a849159c82") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("71e11f91-5e42-469d-a395-01b5b826b883"), new Guid("9b14c6c1-9d29-4aac-b73f-60a849159c82") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71e11f91-5e42-469d-a395-01b5b826b883"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b14c6c1-9d29-4aac-b73f-60a849159c82"));

            migrationBuilder.AddColumn<string>(
                name: "ImagesIds",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7454e9c8-d3ef-47b3-9ef4-588484808b55"), "a009a3c6-cfcd-4d57-856f-730ab7ddcf9a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3046b59f-8f49-4190-9202-09f9f2a61130"), 0, "cfb9478c-d923-47cd-b15a-66b2df24fc98", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEOJ6MKzjlSrqEffs28DE7sq2xGg4gtCBzKb1qRKhgVuhm/lG8J6lCVpezJ1+hCZqYQ==", null, false, "2c06bb54-3065-4959-8d24-328729c38744", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7454e9c8-d3ef-47b3-9ef4-588484808b55"), new Guid("3046b59f-8f49-4190-9202-09f9f2a61130") });
        }
    }
}
