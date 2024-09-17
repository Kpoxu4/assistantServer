using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assistantServer.data.Migrations
{
    /// <inheritdoc />
    public partial class ranameFildToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tokin",
                table: "Users",
                newName: "Token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Tokin");
        }
    }
}
