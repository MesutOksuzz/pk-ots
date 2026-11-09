using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ots.Api.Migrations.PostgreSql
{
    /// <inheritdoc />
    public partial class Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                schema: "dbo",
                table: "Customer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                schema: "dbo",
                table: "Customer",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                schema: "dbo",
                table: "Customer");
        }
    }
}
