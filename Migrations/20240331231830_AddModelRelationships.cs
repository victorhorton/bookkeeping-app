using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookkeepingapp.Migrations
{
    /// <inheritdoc />
    public partial class AddModelRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BatchId",
                table: "Transactions",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompanyId",
                table: "Transactions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AccountId",
                table: "Entries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TransactionId",
                table: "Entries",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Accounts_AccountId",
                table: "Entries",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Transactions_TransactionId",
                table: "Entries",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Batches_BatchId",
                table: "Transactions",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Companies_CompanyId",
                table: "Transactions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Accounts_AccountId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Transactions_TransactionId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Batches_BatchId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Companies_CompanyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BatchId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CompanyId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Entries_AccountId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_TransactionId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Entries");
        }
    }
}
