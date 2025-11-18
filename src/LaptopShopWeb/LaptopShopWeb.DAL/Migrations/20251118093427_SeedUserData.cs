using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaptopShopWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "PhoneNumber", "PostalCode", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Admin Street", "Ho Chi Minh City", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "admin@laptopshop.com", "Administrator", true, null, "$2a$11$9bIBlTrCHumoYs1INYZ7h.1kMnYBwQtJ.5WBsjfgpK/NxYAEmXMLW", "0123456789", null, "Admin", null },
                    { 2, "456 Customer Street", "Hanoi", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "customer@test.com", "Test Customer", true, null, "$2a$11$bmGYq9YBj7zcdk9W6ZDXXeQL1RJ3ja4IvkcR9mFlPGb8IsA1LHS5u", "0987654321", null, "Customer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
