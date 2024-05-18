using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSwipe_API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSwipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Swipes");

            migrationBuilder.AddColumn<bool>(
                name: "IsMatch",
                table: "Matches",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CompanyUsers",
                keyColumn: "Id",
                keyValue: new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                column: "Location",
                value: new List<string> { "TestLocation" });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3643), new List<string> { "Location 10" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3630), new List<string> { "Location 8" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3623), new List<string> { "Location 7" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3617), new List<string> { "Location 6" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3603), new List<string> { "Location 4" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3610), new List<string> { "Location 5" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3596), new List<string> { "Location 3" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3588), new List<string> { "Location 2" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3510), new List<string> { "Location 1" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 15, 8, 26, 19, 993, DateTimeKind.Utc).AddTicks(3636), new List<string> { "Location 9" } });

            migrationBuilder.UpdateData(
                table: "PrivateUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6ff4515-c1cb-4d3d-a268-cdff700f2168"),
                column: "Location",
                value: new List<string> { "Behind you..." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMatch",
                table: "Matches");

            migrationBuilder.CreateTable(
                name: "Swipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsLike = table.Column<bool>(type: "boolean", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swipes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CompanyUsers",
                keyColumn: "Id",
                keyValue: new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                column: "Location",
                value: new List<string> { "TestLocation" });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3914), new List<string> { "Location 10" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3899), new List<string> { "Location 8" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3891), new List<string> { "Location 7" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3883), new List<string> { "Location 6" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3867), new List<string> { "Location 4" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3875), new List<string> { "Location 5" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3859), new List<string> { "Location 3" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3849), new List<string> { "Location 2" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3752), new List<string> { "Location 1" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3907), new List<string> { "Location 9" } });

            migrationBuilder.UpdateData(
                table: "PrivateUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6ff4515-c1cb-4d3d-a268-cdff700f2168"),
                column: "Location",
                value: new List<string> { "Behind you..." });
        }
    }
}
