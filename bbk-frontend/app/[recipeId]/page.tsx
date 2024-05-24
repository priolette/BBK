import { dummyRecipes } from "@/data/recipes";
import { getRecipe } from "@/lib/server/recipes";
import Image from "next/image";

async function getRecipeDetails(recipeId: number) {
  const getRecipesPath = process.env.API_PATH + "recipes/" + recipeId;

  const res = await fetch(getRecipesPath);
  if (!res.ok) {
    //what solution for errors ? Message component or some kind of notification
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function Page({
  params,
}: {
  params: { recipeId: number };
}) {
  const recipeData = await getRecipe(params.recipeId);
  const dummyImage =
    "https://handletheheat.com/wp-content/uploads/2017/03/Chewy-Brownies-Square-1.jpg";
  const dummyAuthor = "Coming soon";

  if (!recipeData) {
    return <div>Recipe not found</div>;
  }

  return (
    <div className="mx-auto max-w-3xl p-4">
      <h1 className="mb-4 text-3xl font-bold">{recipeData.title}</h1>
      <Image
        src={dummyImage}
        alt={recipeData.title ?? "Recipe image"}
        className="mb-4 w-96 rounded-lg"
        width={150}
        height={100}
      />
      <p className="mb-4 text-lg">{recipeData.description}</p>
      <h2 className="mb-2 text-2xl font-semibold">Ingredients:</h2>
      <ul className="ml-6 list-disc">
        {recipeData.ingredients.map((ingredient) => (
          <li key={ingredient.id} className="mb-1">
            {ingredient.amount} {ingredient.unit.name} of{" "}
            {ingredient.ingredient.name}
          </li>
        ))}
      </ul>
      <h2 className="mb-2 mt-8 text-2xl font-semibold">Steps:</h2>
      {/* api does not provide it yet */}
      {/* <ol className="ml-6 list-decimal">
        {recipeData.steps.map((step:string, index: number) => (
          <li key={index} className="mb-1">
            {step}
          </li>
        ))}
      </ol> */}
      <p className="mt-8">Created by: {dummyAuthor}</p>

      <h2 className="my-4 text-2xl font-semibold">Comments:</h2>
      <ul className="ml-6 list-disc">
        {/* {recipeData.comments?.map((comment: string, index: number) => (
          <li key={index} className="mb-1">
            {comment}
          </li>
        ))} */}
      </ul>
    </div>
  );
}
