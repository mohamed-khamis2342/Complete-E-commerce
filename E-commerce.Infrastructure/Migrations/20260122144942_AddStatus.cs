using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cancellationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cancellationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "refundMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refundMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "refundStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refundStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "cancellationStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Pending" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Approved" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), " Rejected " }
                });

            migrationBuilder.InsertData(
                table: "paymentStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Pending" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Completed" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Failed" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Refunded" }
                });

            migrationBuilder.InsertData(
                table: "refundMethods",
                columns: new[] { "Id", "Method" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), "Original" },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), "PayPal" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), "Stripe" },
                    { new Guid("d4444444-4444-4444-4444-444444444444"), "BankTransfer" },
                    { new Guid("e5555555-5555-5555-5555-555555555555"), "Manual" }
                });

            migrationBuilder.InsertData(
                table: "refundStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Pending" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Completed" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Failed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cancellationStatuses");

            migrationBuilder.DropTable(
                name: "paymentStatuses");

            migrationBuilder.DropTable(
                name: "refundMethods");

            migrationBuilder.DropTable(
                name: "refundStatuses");
        }
    }
}
