import { UpdateRecipeForm } from "@/app/me/recipes/[recipeId]/edit/_components/update-recipe-form";
import { getAllIngredients } from "@/lib/server/ingredients";
import { getRecipe } from "@/lib/server/recipes";
import { getAllUnits } from "@/lib/server/units";
import { notFound } from "next/navigation";

export default async function EditRecipePage({
  params,
}: {
  params: { recipeId: number };
}) {
  const [recipe, { data: ingredients }, units] = await Promise.all([
    getRecipe(params.recipeId),
    getAllIngredients(),
    getAllUnits(),
  ]);

  if (!recipe || !ingredients || !units) {
    notFound();
  }

  return (
    <div className="xl:px-80">
      <h1 className="px-4 pb-2 pt-4 text-2xl font-bold">Edit Recipe</h1>
      <UpdateRecipeForm
        recipe={recipe}
        ingredients={ingredients}
        units={units}
      />
    </div>
  );
}
