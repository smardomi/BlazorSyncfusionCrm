using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorSyncfusionCrm.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateOfBirth", "DateUpdated", "FirstName", "IsDeleted", "LastName", "NickName", "Place" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7974), null, new DateTime(1995, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Saeed", false, "Mardomi", "Fasterrr", "Tabriz" },
                    { 2, new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7993), null, new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vahid", false, "Mardomi", "Vh", "Tabriz" },
                    { 3, new DateTime(2023, 5, 7, 9, 58, 35, 476, DateTimeKind.Local).AddTicks(7995), null, new DateTime(1988, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fereshteh", false, "Sadeghi", "FS", "USA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
