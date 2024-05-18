using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSwipe_API.Migrations
{
    /// <inheritdoc />
    public partial class AlteredSeededEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CompanyUsers",
                keyColumn: "Id",
                keyValue: new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                columns: new[] { "Email", "Location" },
                values: new object[] { "company@test.com", new List<string> { "TestLocation" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9464), new List<string> { "Location 10" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9443), new List<string> { "Location 8" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9434), new List<string> { "Location 7" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9424), new List<string> { "Location 6" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9404), new List<string> { "Location 4" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9414), new List<string> { "Location 5" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9393), new List<string> { "Location 3" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9381), new List<string> { "Location 2" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9244), new List<string> { "Location 1" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 37, 27, 996, DateTimeKind.Utc).AddTicks(9453), new List<string> { "Location 9" } });

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
            migrationBuilder.UpdateData(
                table: "CompanyUsers",
                keyColumn: "Id",
                keyValue: new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                columns: new[] { "Email", "Location" },
                values: new object[] { "company@example.com", new List<string> { "TestLocation" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3481), new List<string> { "Location 10" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3468), new List<string> { "Location 8" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3462), new List<string> { "Location 7" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3455), new List<string> { "Location 6" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3442), new List<string> { "Location 4" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3449), new List<string> { "Location 5" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3435), new List<string> { "Location 3" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3428), new List<string> { "Location 2" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3347), new List<string> { "Location 1" } });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                columns: new[] { "FinalApplicationDate", "Location" },
                values: new object[] { new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3475), new List<string> { "Location 9" } });

            migrationBuilder.UpdateData(
                table: "PrivateUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6ff4515-c1cb-4d3d-a268-cdff700f2168"),
                column: "Location",
                value: new List<string> { "Behind you..." });
        }
    }
}
