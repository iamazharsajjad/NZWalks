using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Hard" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Medium" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1e1f5e5e-5e5e-4e4e-8e8e-1e1f5e5e5e5e"), "AKL", "Auckland", "https://example.com/auckland.jpg" },
                    { new Guid("2f2f6f6f-6f6f-4f4f-9f9f-2f2f6f6f6f6f"), "WLG", "Wellington", "https://example.com/wellington.jpg" },
                    { new Guid("3a3a7a7a-7a7a-4a4a-afaf-3a3a7a7a7a7a"), "CHC", "Christchurch", "https://example.com/christchurch.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e1f5e5e-5e5e-4e4e-8e8e-1e1f5e5e5e5e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2f2f6f6f-6f6f-4f4f-9f9f-2f2f6f6f6f6f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3a3a7a7a-7a7a-4a4a-afaf-3a3a7a7a7a7a"));
        }
    }
}
