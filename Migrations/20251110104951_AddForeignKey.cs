using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication11.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateHired",
                value: new DateTime(2025, 11, 10, 10, 49, 51, 210, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateHired",
                value: new DateTime(2025, 11, 10, 10, 49, 51, 210, DateTimeKind.Utc).AddTicks(7830));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "DateHired",
                value: new DateTime(2025, 11, 10, 2, 12, 38, 349, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "DateHired",
                value: new DateTime(2025, 11, 10, 2, 12, 38, 349, DateTimeKind.Utc).AddTicks(120));
        }
    }
}
