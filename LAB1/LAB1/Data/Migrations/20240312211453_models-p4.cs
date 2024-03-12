using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Data.Migrations
{
    /// <inheritdoc />
    public partial class modelsp4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "HeldById",
                table: "Tickets",
                newName: "ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_HeldById",
                table: "Tickets",
                newName: "IX_Tickets_ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ConcertId",
                table: "Tickets",
                newName: "HeldById");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets",
                newName: "IX_Tickets_HeldById");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets",
                column: "HeldById",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
