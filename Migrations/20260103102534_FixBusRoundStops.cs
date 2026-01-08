using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginData.Migrations
{
    /// <inheritdoc />
    public partial class FixBusRoundStops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StopsJson1",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StopsJson1",
                table: "Routes");
        }
    }
}
