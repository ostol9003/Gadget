using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gadget.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class addIsPromotedtoProductentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "Products");
        }
    }
}
