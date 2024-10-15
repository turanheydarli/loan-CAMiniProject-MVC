using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MerchantUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BusinessLicensePath",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStep",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNotes",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c5098b3-d0d4-49c2-a59e-7ea06d289711", "11e80a96-78ae-442c-99db-c2518625c10c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1380281e-e7d5-4a44-af90-882ebf52103f", 0, "65be86e8-f578-4ce7-8121-676fa6370cd6", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEAGNX5Zahr4XzePoIheSoLWijGbmvVayzRCaamzIW73U4MOgCj0m+PjBPLlMyvJZlQ==", null, false, "fa91ab0d-16f9-4cdd-828d-1020b29369b3", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9c5098b3-d0d4-49c2-a59e-7ea06d289711", "1380281e-e7d5-4a44-af90-882ebf52103f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c5098b3-d0d4-49c2-a59e-7ea06d289711", "1380281e-e7d5-4a44-af90-882ebf52103f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c5098b3-d0d4-49c2-a59e-7ea06d289711");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1380281e-e7d5-4a44-af90-882ebf52103f");

            migrationBuilder.DropColumn(
                name: "BusinessLicensePath",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "CurrentStep",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "RegistrationNotes",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Merchants");

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
    }
}
