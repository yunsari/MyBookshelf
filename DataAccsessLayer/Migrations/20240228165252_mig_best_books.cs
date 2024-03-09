using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_best_books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Books");
        }
    }
}
