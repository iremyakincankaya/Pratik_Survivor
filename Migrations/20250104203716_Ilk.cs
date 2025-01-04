using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pratik_Survivor.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedDate", "IsDeleted", "ModifiedDate", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3828), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ünlüler", null },
                    { 2, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3835), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gönüllüler", null }
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedDate", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3925), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aleyna", false, "Avcı", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3929), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hadise", false, "Açıkgöz", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3930), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmet", false, "Yılmaz", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 2, new DateTime(2025, 1, 4, 20, 37, 16, 570, DateTimeKind.Utc).AddTicks(3931), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayşe", false, "Karaca", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CategoryId",
                table: "Competitors",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
