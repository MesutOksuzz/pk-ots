using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ots.Api.Migrations
{
    /// <inheritdoc />
    public partial class OdevDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) BaseEntity alan adları: veri korunarak yeniden adlandırılıyor
            // Customer
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "Customer", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "Customer", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "Customer", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "Customer", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[Customer] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "Customer", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "Customer", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "Customer", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AlterColumn<bool>(name: "IsActive", schema: "dbo", table: "Customer", type: "bit", nullable: false, defaultValue: true,
                oldClrType: typeof(bool), oldType: "bit", oldNullable: false);

            // CustomerAddress
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "CustomerAddress", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "CustomerAddress", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "CustomerAddress", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "CustomerAddress", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[CustomerAddress] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "CustomerAddress", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "CustomerAddress", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "CustomerAddress", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", schema: "dbo", table: "CustomerAddress", type: "bit", nullable: false, defaultValue: true);

            // CustomerPhone
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "CustomerPhone", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "CustomerPhone", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "CustomerPhone", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "CustomerPhone", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[CustomerPhone] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "CustomerPhone", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "CustomerPhone", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "CustomerPhone", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", schema: "dbo", table: "CustomerPhone", type: "bit", nullable: false, defaultValue: true);

            // Account
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "Account", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "Account", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "Account", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "Account", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[Account] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "Account", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "Account", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "Account", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", schema: "dbo", table: "Account", type: "bit", nullable: false, defaultValue: true);

            // AccountTransaction
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "AccountTransaction", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "AccountTransaction", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "AccountTransaction", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "AccountTransaction", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[AccountTransaction] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "AccountTransaction", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "AccountTransaction", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "AccountTransaction", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", schema: "dbo", table: "AccountTransaction", type: "bit", nullable: false, defaultValue: true);

            // MoneyTransfer
            migrationBuilder.RenameColumn(name: "InsertDate", schema: "dbo", table: "MoneyTransfer", newName: "InsertedDate");
            migrationBuilder.RenameColumn(name: "InsertUser", schema: "dbo", table: "MoneyTransfer", newName: "InsertedUser");
            migrationBuilder.RenameColumn(name: "UpdateDate", schema: "dbo", table: "MoneyTransfer", newName: "UpdatedDate");
            migrationBuilder.RenameColumn(name: "UpdateUser", schema: "dbo", table: "MoneyTransfer", newName: "UpdatedUser");
            migrationBuilder.Sql("UPDATE [dbo].[MoneyTransfer] SET [InsertedUser] = N'system' WHERE [InsertedUser] IS NULL;");
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "MoneyTransfer", type: "nvarchar(250)", maxLength: 250, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "MoneyTransfer", type: "nvarchar(250)", maxLength: 250, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "MoneyTransfer", type: "datetime2", nullable: true,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", schema: "dbo", table: "MoneyTransfer", type: "bit", nullable: false, defaultValue: true);

            // 2) Account: açılış/kapanış tarihi, bakiye hassasiyeti
            migrationBuilder.AlterColumn<decimal>(name: "Balance", schema: "dbo", table: "Account", type: "decimal(18,2)", nullable: false, precision: 18, scale: 2,
                oldClrType: typeof(decimal), oldType: "decimal(18,4)", oldNullable: false, oldPrecision: 18, oldScale: 4);
            migrationBuilder.AddColumn<DateTime>(name: "OpenDate", schema: "dbo", table: "Account", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<DateTime>(name: "CloseDate", schema: "dbo", table: "Account", type: "datetime2", nullable: true);

            // 3) AccountTransaction: tek Amount yerine giriş/çıkış kolonları
            migrationBuilder.DropColumn(name: "Amount", schema: "dbo", table: "AccountTransaction");
            migrationBuilder.AddColumn<decimal>(name: "DebitAmount", schema: "dbo", table: "AccountTransaction", type: "decimal(18,4)", precision: 18, scale: 4, nullable: true);
            migrationBuilder.AddColumn<decimal>(name: "CreditAmount", schema: "dbo", table: "AccountTransaction", type: "decimal(18,4)", precision: 18, scale: 4, nullable: true);
            migrationBuilder.AddColumn<string>(name: "TransferType", schema: "dbo", table: "AccountTransaction", type: "nvarchar(50)", maxLength: 50, nullable: true);

            // 4) CustomerAddress: Country -> CountryCode (3 karakter), IsDefault
            migrationBuilder.RenameColumn(name: "Country", schema: "dbo", table: "CustomerAddress", newName: "CountryCode");
            migrationBuilder.Sql("UPDATE [dbo].[CustomerAddress] SET [CountryCode] = UPPER(LEFT([CountryCode], 3)) WHERE LEN([CountryCode]) > 3;");
            migrationBuilder.AlterColumn<string>(name: "CountryCode", schema: "dbo", table: "CustomerAddress", type: "nvarchar(3)", maxLength: 3, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(100)", oldMaxLength: 100, oldNullable: false);
            migrationBuilder.AddColumn<bool>(name: "IsDefault", schema: "dbo", table: "CustomerAddress", type: "bit", nullable: false, defaultValue: false);

            // 5) MoneyTransfer: masraf
            migrationBuilder.AddColumn<decimal>(name: "FeeAmount", schema: "dbo", table: "MoneyTransfer", type: "decimal(18,4)", precision: 18, scale: 4, nullable: true);

            // 6) Yeni tablo: EftTransaction
            migrationBuilder.CreateTable(
                name: "EftTransaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    ReveiverIban = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(16,4)", precision: 16, scale: 4, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentCategoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertedUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EftTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EftTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EftTransaction_AccountId",
                schema: "dbo",
                table: "EftTransaction",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EftTransaction", schema: "dbo");

            migrationBuilder.DropColumn(name: "FeeAmount", schema: "dbo", table: "MoneyTransfer");
            migrationBuilder.DropColumn(name: "IsDefault", schema: "dbo", table: "CustomerAddress");
            migrationBuilder.AlterColumn<string>(name: "CountryCode", schema: "dbo", table: "CustomerAddress", type: "nvarchar(100)", maxLength: 100, nullable: false,
                oldClrType: typeof(string), oldType: "nvarchar(3)", oldMaxLength: 3, oldNullable: false);
            migrationBuilder.RenameColumn(name: "CountryCode", schema: "dbo", table: "CustomerAddress", newName: "Country");
            migrationBuilder.DropColumn(name: "TransferType", schema: "dbo", table: "AccountTransaction");
            migrationBuilder.DropColumn(name: "CreditAmount", schema: "dbo", table: "AccountTransaction");
            migrationBuilder.DropColumn(name: "DebitAmount", schema: "dbo", table: "AccountTransaction");
            migrationBuilder.AddColumn<decimal>(name: "Amount", schema: "dbo", table: "AccountTransaction", type: "decimal(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m);
            migrationBuilder.DropColumn(name: "CloseDate", schema: "dbo", table: "Account");
            migrationBuilder.DropColumn(name: "OpenDate", schema: "dbo", table: "Account");
            migrationBuilder.AlterColumn<decimal>(name: "Balance", schema: "dbo", table: "Account", type: "decimal(18,4)", nullable: false, precision: 18, scale: 4,
                oldClrType: typeof(decimal), oldType: "decimal(18,2)", oldNullable: false, oldPrecision: 18, oldScale: 2);

            migrationBuilder.AlterColumn<bool>(name: "IsActive", schema: "dbo", table: "Customer", type: "bit", nullable: false,
                oldClrType: typeof(bool), oldType: "bit", oldNullable: false, oldDefaultValue: true);
            migrationBuilder.Sql("UPDATE [dbo].[Customer] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "Customer", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "Customer", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "Customer", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "Customer", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "Customer", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "Customer", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "Customer", newName: "InsertDate");

            migrationBuilder.DropColumn(name: "IsActive", schema: "dbo", table: "CustomerAddress");
            migrationBuilder.Sql("UPDATE [dbo].[CustomerAddress] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "CustomerAddress", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "CustomerAddress", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "CustomerAddress", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "CustomerAddress", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "CustomerAddress", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "CustomerAddress", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "CustomerAddress", newName: "InsertDate");

            migrationBuilder.DropColumn(name: "IsActive", schema: "dbo", table: "CustomerPhone");
            migrationBuilder.Sql("UPDATE [dbo].[CustomerPhone] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "CustomerPhone", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "CustomerPhone", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "CustomerPhone", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "CustomerPhone", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "CustomerPhone", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "CustomerPhone", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "CustomerPhone", newName: "InsertDate");

            migrationBuilder.DropColumn(name: "IsActive", schema: "dbo", table: "Account");
            migrationBuilder.Sql("UPDATE [dbo].[Account] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "Account", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "Account", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "Account", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "Account", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "Account", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "Account", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "Account", newName: "InsertDate");

            migrationBuilder.DropColumn(name: "IsActive", schema: "dbo", table: "AccountTransaction");
            migrationBuilder.Sql("UPDATE [dbo].[AccountTransaction] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "AccountTransaction", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "AccountTransaction", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "AccountTransaction", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "AccountTransaction", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "AccountTransaction", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "AccountTransaction", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "AccountTransaction", newName: "InsertDate");

            migrationBuilder.DropColumn(name: "IsActive", schema: "dbo", table: "MoneyTransfer");
            migrationBuilder.Sql("UPDATE [dbo].[MoneyTransfer] SET [UpdatedDate] = [InsertedDate] WHERE [UpdatedDate] IS NULL;");
            migrationBuilder.AlterColumn<DateTime>(name: "UpdatedDate", schema: "dbo", table: "MoneyTransfer", type: "datetime2", nullable: false,
                oldClrType: typeof(DateTime), oldType: "datetime2", oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "UpdatedUser", schema: "dbo", table: "MoneyTransfer", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: true);
            migrationBuilder.AlterColumn<string>(name: "InsertedUser", schema: "dbo", table: "MoneyTransfer", type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(250)", oldMaxLength: 250, oldNullable: false);
            migrationBuilder.RenameColumn(name: "UpdatedUser", schema: "dbo", table: "MoneyTransfer", newName: "UpdateUser");
            migrationBuilder.RenameColumn(name: "UpdatedDate", schema: "dbo", table: "MoneyTransfer", newName: "UpdateDate");
            migrationBuilder.RenameColumn(name: "InsertedUser", schema: "dbo", table: "MoneyTransfer", newName: "InsertUser");
            migrationBuilder.RenameColumn(name: "InsertedDate", schema: "dbo", table: "MoneyTransfer", newName: "InsertDate");
        }
    }
}
