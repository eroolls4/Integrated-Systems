using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Data.Migrations
{
    /// <inheritdoc />
    public partial class modelsp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcertImage",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertImage",
                table: "Concerts");
        }
    }
}
