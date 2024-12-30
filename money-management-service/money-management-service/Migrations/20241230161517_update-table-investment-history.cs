using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace money_management_service.Migrations
{
    /// <inheritdoc />
    public partial class updatetableinvestmenthistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyingDate",
                table: "InvestmentHistory");

            migrationBuilder.DropColumn(
                name: "BuyingPrice",
                table: "InvestmentHistory");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "InvestmentHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentHistory_Transactions_TransactionId",
                table: "InvestmentHistory",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentHistory_Transactions_TransactionId",
                table: "InvestmentHistory");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "InvestmentHistory");

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyingDate",
                table: "InvestmentHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "BuyingPrice",
                table: "InvestmentHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
