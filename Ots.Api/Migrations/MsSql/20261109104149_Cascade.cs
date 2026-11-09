using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ots.Api.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                schema: "dbo",
                table: "Account",
                column: "CustomerId",
                principalSchema: "dbo",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransaction_Account_AccountId",
                schema: "dbo",
                table: "AccountTransaction",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
