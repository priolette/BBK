using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRecipeIngredientsRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Steps_StepId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_StepId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_UnitId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "StepId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitId",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "public",
                table: "Ingredients",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "public",
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "public",
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "public",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                schema: "public",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                schema: "public",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_UnitId",
                schema: "public",
                table: "RecipeIngredients",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "public",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                schema: "public",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                schema: "public",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                schema: "public",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                schema: "public",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_StepId",
                schema: "public",
                table: "Ingredients",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UnitId",
                schema: "public",
                table: "Ingredients",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                schema: "public",
                table: "Ingredients",
                column: "RecipeId",
                principalSchema: "public",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Steps_StepId",
                schema: "public",
                table: "Ingredients",
                column: "StepId",
                principalSchema: "public",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                schema: "public",
                table: "Ingredients",
                column: "UnitId",
                principalSchema: "public",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
