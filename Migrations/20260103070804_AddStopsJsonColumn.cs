using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginData.Migrations
{
    /// <inheritdoc />
    public partial class AddStopsJsonColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stops",
                table: "Routes",
                newName: "StopsJson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StopsJson",
                table: "Routes",
                newName: "Stops");
        }
    }
}
