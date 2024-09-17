using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assistantServer.data.Migrations
{
    /// <inheritdoc />
    public partial class addTokin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tokin",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tokin",
                table: "Users");
        }
    }
}
