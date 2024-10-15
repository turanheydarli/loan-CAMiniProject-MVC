using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CarouselItemAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "767137f5-4964-4b57-8e87-a78e062faf45", "313355cd-522e-4c0f-9126-8693aec1869d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "767137f5-4964-4b57-8e87-a78e062faf45");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "313355cd-522e-4c0f-9126-8693aec1869d");

            migrationBuilder.CreateTable(
                name: "CarouselItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "613d6bd3-b6c7-4e92-80f1-31edd06b4bbe", "0639a27d-351c-4bfb-9bea-3593871e2c98", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2e25595-7197-4d1b-822b-df8b2dcfa055", 0, "4b532f8c-457c-4a3d-b69a-2018f3dbe3ae", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAED5M/P25uJQcF8E77cG86I3zMtOF1cs/xMhq50IQj2vJVGD8nJHb7/lYQUJjR5YLRg==", null, false, "ac7702cd-c2f0-4443-aec1-0c522c79c110", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "613d6bd3-b6c7-4e92-80f1-31edd06b4bbe", "c2e25595-7197-4d1b-822b-df8b2dcfa055" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarouselItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "613d6bd3-b6c7-4e92-80f1-31edd06b4bbe", "c2e25595-7197-4d1b-822b-df8b2dcfa055" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613d6bd3-b6c7-4e92-80f1-31edd06b4bbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2e25595-7197-4d1b-822b-df8b2dcfa055");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "767137f5-4964-4b57-8e87-a78e062faf45", "9d6eaec1-a2bf-4b66-b44c-798003220db1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "313355cd-522e-4c0f-9126-8693aec1869d", 0, "a2c0edf7-e38e-4aee-b44c-86e6ff8ea25d", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEGI5j+a3b09gtiVbMpARm+6Um2utSZfxZ55muHXQyGfO+VskxF1OwP2wQhh0tzle+Q==", null, false, "c3070f6f-de2f-452c-86da-d9f256ffa510", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "767137f5-4964-4b57-8e87-a78e062faf45", "313355cd-522e-4c0f-9126-8693aec1869d" });
        }
    }
}
