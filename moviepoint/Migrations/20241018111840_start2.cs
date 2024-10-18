using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviepoint.Migrations
{
    /// <inheritdoc />
    public partial class start2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cinemald",
                table: "movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cinemald",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
