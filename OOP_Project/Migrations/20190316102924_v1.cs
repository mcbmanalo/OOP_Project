using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OOP_Project.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<long>(nullable: false),
                    JewelryType = table.Column<string>(nullable: true),
                    JewelryQuality = table.Column<string>(nullable: true),
                    JewelryWeight = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    OtherDetails = table.Column<string>(nullable: true),
                    ActualValue = table.Column<double>(nullable: false),
                    AmountLoaned = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    DateOfTransaction = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    PaymentTransactionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<long>(nullable: false),
                    AmountLoaned = table.Column<double>(nullable: false),
                    AccumulatedAmount = table.Column<double>(nullable: false),
                    AmountPaid = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    DateOfTransaction = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.PaymentTransactionsId);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_TransactionId",
                table: "PaymentTransactions",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
