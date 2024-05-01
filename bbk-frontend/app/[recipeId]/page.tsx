import { dummyRecipes } from "@/data/recipes";
import Image from "next/image";

export default function Page({ params }: { params: { recipeId: number } }) {
  const recipeData = dummyRecipes.find(
    (recipe) => recipe.id == params.recipeId,
  );

  if (!recipeData) {
    return <div>Recipe not found</div>;
  }

  return (
    <div className="mx-auto max-w-3xl p-4">
      <h1 className="mb-4 text-3xl font-bold">{recipeData.name}</h1>
      <Image
        src={recipeData.image}
        alt={recipeData.name}
        className="mb-4 w-full rounded-lg"
        width={0}
        height={0}
        sizes="100vw"
      />
      <p className="mb-4 text-lg">{recipeData.description}</p>
      <h2 className="mb-2 text-2xl font-semibold">Ingredients:</h2>
      <ul className="ml-6 list-disc">
        {recipeData.ingredients?.map((ingredient, index) => (
          <li key={index} className="mb-1">
            {ingredient}
          </li>
        ))}
      </ul>
      <h2 className="mb-2 mt-8 text-2xl font-semibold">Steps:</h2>
      <ol className="ml-6 list-decimal">
        {recipeData.steps.map((step, index) => (
          <li key={index} className="mb-1">
            {step}
          </li>
        ))}
      </ol>
      <p className="mt-8">Created by: {recipeData.author}</p>
    </div>
  );
}
