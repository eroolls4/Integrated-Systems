using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class modelsp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_Order_OrderId",
                table: "TicketInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrder_Tickets_TicketId",
                table: "TicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder");

            migrationBuilder.RenameTable(
                name: "TicketInOrder",
                newName: "TicketInOrders");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInOrder_TicketId",
                table: "TicketInOrders",
                newName: "IX_TicketInOrders_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInOrder_OrderId",
                table: "TicketInOrders",
                newName: "IX_TicketInOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrders_Order_OrderId",
                table: "TicketInOrders",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrders_Tickets_TicketId",
                table: "TicketInOrders",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrders_Order_OrderId",
                table: "TicketInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketInOrders_Tickets_TicketId",
                table: "TicketInOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.RenameTable(
                name: "TicketInOrders",
                newName: "TicketInOrder");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrder",
                newName: "IX_TicketInOrder_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketInOrders_OrderId",
                table: "TicketInOrder",
                newName: "IX_TicketInOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrder",
                table: "TicketInOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_Order_OrderId",
                table: "TicketInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketInOrder_Tickets_TicketId",
                table: "TicketInOrder",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
