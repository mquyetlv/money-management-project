using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace money_management_service.Migrations
{
    /// <inheritdoc />
    public partial class updateinvestmenthistortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory",
                column: "TransactionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentHistory_TransactionId",
                table: "InvestmentHistory",
                column: "TransactionId");
        }
    }
}
