using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderColumnToSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                schema: "public",
                table: "Steps",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                schema: "public",
                table: "Steps");
        }
    }
}
