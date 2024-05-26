import { CreateIngredientForm } from "@/app/create/ingredient/_components/create-ingredient-form";

export default function CreateIngredientPage() {
  return (
    <div className="xl:px-80">
      <h1 className="px-4 pb-2 pt-4 text-2xl font-bold">
        Create New Ingredient
      </h1>
      <CreateIngredientForm />
    </div>
  );
}
