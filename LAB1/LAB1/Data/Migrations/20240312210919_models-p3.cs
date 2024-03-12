using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Data.Migrations
{
    /// <inheritdoc />
    public partial class modelsp3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeldById",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets",
                column: "HeldById",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "HeldById",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_HeldById",
                table: "Tickets",
                column: "HeldById",
                principalTable: "Concerts",
                principalColumn: "Id");
        }
    }
}
