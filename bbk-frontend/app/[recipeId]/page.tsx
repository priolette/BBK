import { dummyRecipes } from "@/data/recipies";

export default function Page({ params }: { params: { recipeId: number } }) {
  console.log(params.recipeId)
  const recipeData = dummyRecipes.find((recipe) => recipe.id == params.recipeId);
  console.log("testttt")
  console.log(recipeData)
  if (!recipeData) {
    return <div>Recipe not found</div>;
  }

  return (
    <div className="max-w-3xl mx-auto p-4">
      <h1 className="text-3xl font-bold mb-4">{recipeData.name}</h1>
      <img src={recipeData.image} alt={recipeData.name} className="w-full rounded-lg mb-4" />
      <p className="text-lg mb-4">{recipeData.description}</p>

      <h2 className="text-2xl font-semibold mb-2">Ingredients:</h2>
      <ul className="list-disc ml-6">
        {recipeData.ingredients?.map((ingredient, index) => (
          <li key={index} className="mb-1">{ingredient}</li>
        ))}
      </ul>

      <h2 className="text-2xl font-semibold mb-2 mt-8">Steps:</h2>
      <ol className="list-decimal ml-6">
        {recipeData.steps.map((step, index) => (
          <li key={index} className="mb-1">{step}</li>
        ))}
      </ol>

      <p className="mt-8">Created by: {recipeData.author}</p>
    </div>
  );
}
