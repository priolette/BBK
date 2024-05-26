import { CreateRecipeForm } from "@/app/create/_components/create-recipe-form";
import { getAllIngredients } from "@/lib/server/ingredients";
import { getAllUnits } from "@/lib/server/units";

export default async function CreateRecipePage() {
  const [ingredients, units] = await Promise.all([
    getAllIngredients(),
    getAllUnits(),
  ]);

  return (
    <div className="xl:px-80">
      <h1 className="px-4 pb-2 pt-4 text-2xl font-bold">Create New Recipe</h1>
      <CreateRecipeForm ingredients={ingredients.data} units={units} />
    </div>
  );
}
