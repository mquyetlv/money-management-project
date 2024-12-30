using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace money_management_service.Migrations
{
    /// <inheritdoc />
    public partial class addtableinvestment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentPortfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentPortfolio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyingPrice = table.Column<long>(type: "bigint", nullable: false),
                    BuyingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvestmentPortfolioId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentHistory_InvestmentPortfolio_InvestmentPortfolioId",
                        column: x => x.InvestmentPortfolioId,
                        principalTable: "InvestmentPortfolio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentHistory_InvestmentPortfolioId",
                table: "InvestmentHistory",
                column: "InvestmentPortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentHistory");

            migrationBuilder.DropTable(
                name: "InvestmentPortfolio");
        }
    }
}
