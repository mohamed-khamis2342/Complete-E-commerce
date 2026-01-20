using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cancellations");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), "Pending" },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), "Processing" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), "Shipped" },
                    { new Guid("d4444444-4444-4444-4444-444444444444"), "Delivered" },
                    { new Guid("e5555555-5555-5555-5555-555555555555"), "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Refunds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Cancellations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
