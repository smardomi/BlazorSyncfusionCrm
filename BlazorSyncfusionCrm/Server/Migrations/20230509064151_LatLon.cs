using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class LatLon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Contacts",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 9, 10, 11, 51, 429, DateTimeKind.Local).AddTicks(9922), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 9, 10, 11, 51, 429, DateTimeKind.Local).AddTicks(9940), null, null });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Latitude", "Longitude" },
                values: new object[] { new DateTime(2023, 5, 9, 10, 11, 51, 429, DateTimeKind.Local).AddTicks(9942), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7995));
        }
    }
}
