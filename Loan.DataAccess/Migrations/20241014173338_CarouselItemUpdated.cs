using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CarouselItemUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CarouselItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04feadf6-cec0-4b1e-829e-3553c1d5ba30", "34672adc-d461-4449-a20e-cdbe68983dda", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b842eed7-bb9e-4efc-8bc5-aca785b6b885", 0, "3962371f-a4bc-46df-bd18-02bb276c5aa2", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEAiW8lfkeUA30pa+Sc0jjhifVkcXk/sx9UMTxQURNboof8dr7MhlJqC4d5Onu+wcrQ==", null, false, "6eeff145-2ab9-4d60-b06f-1cb12e31dfc1", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "04feadf6-cec0-4b1e-829e-3553c1d5ba30", "b842eed7-bb9e-4efc-8bc5-aca785b6b885" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04feadf6-cec0-4b1e-829e-3553c1d5ba30", "b842eed7-bb9e-4efc-8bc5-aca785b6b885" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04feadf6-cec0-4b1e-829e-3553c1d5ba30");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b842eed7-bb9e-4efc-8bc5-aca785b6b885");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CarouselItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
