using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_AdminId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseds_CustomerId",
                table: "Purchaseds");

            migrationBuilder.DropIndex(
                name: "IX_Products_AdminId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Purchaseds",
                newName: "CustomerName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Purchaseds",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Purchaseds",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "TicketDocs",
                columns: table => new
                {
                    IdOrden = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomertName = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasedIdPurchased = table.Column<Guid>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDocs", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_TicketDocs_Purchaseds_PurchasedIdPurchased",
                        column: x => x.PurchasedIdPurchased,
                        principalTable: "Purchaseds",
                        principalColumn: "IdPurchased",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketDocs_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseds_CustomerId",
                table: "Purchaseds",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDocs_CustomerId",
                table: "TicketDocs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDocs_PurchasedIdPurchased",
                table: "TicketDocs",
                column: "PurchasedIdPurchased");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketDocs");

            migrationBuilder.DropIndex(
                name: "IX_Purchaseds_CustomerId",
                table: "Purchaseds");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Purchaseds");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Purchaseds");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Purchaseds",
                newName: "PurchaseDate");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminId",
                table: "Users",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchaseds_CustomerId",
                table: "Purchaseds",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_AdminId",
                table: "Users",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
