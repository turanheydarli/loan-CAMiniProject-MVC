using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MediaForEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "BusinessLicenseFileId",
                table: "Merchants");

            migrationBuilder.AddColumn<string>(
                name: "ImagesIds",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BannerImageId",
                table: "Merchants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessLicenseId",
                table: "Merchants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImageId",
                table: "Merchants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OwnerType",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "LoanItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileImageId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThumbnailId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BannerImageId",
                table: "CarouselItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_LoanItems_ProductId1",
                table: "LoanItems",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanItems_Products_ProductId1",
                table: "LoanItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanItems_Products_ProductId1",
                table: "LoanItems");

            migrationBuilder.DropIndex(
                name: "IX_LoanItems_ProductId1",
                table: "LoanItems");

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

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BannerImageId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "BusinessLicenseId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "OwnerType",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "LoanItems");

            migrationBuilder.DropColumn(
                name: "ProfileImageId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BannerImageId",
                table: "CarouselItems");

            migrationBuilder.AddColumn<string>(
                name: "BusinessLicenseFileId",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
