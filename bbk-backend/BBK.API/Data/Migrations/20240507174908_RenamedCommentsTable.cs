using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Recipes_RecipeId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_RecipeId",
                schema: "public",
                table: "Comments",
                newName: "IX_Comments_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                schema: "public",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                schema: "public",
                table: "Comments",
                column: "RecipeId",
                principalSchema: "public",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Recipes_RecipeId",
                schema: "public",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                schema: "public",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "public",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RecipeId",
                table: "Comment",
                newName: "IX_Comment_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Recipes_RecipeId",
                table: "Comment",
                column: "RecipeId",
                principalSchema: "public",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
