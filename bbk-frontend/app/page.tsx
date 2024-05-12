import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Recipe } from "@/types/Recipe";
import Image from "next/image";
import Link from "next/link";

async function getRecipes() {
  const getRecipesPath = process.env.API_PATH + "recipes";

  const res = await fetch(getRecipesPath);
  if (!res.ok) {
    //what solution for errors ? Message component or some kind of notification
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function Home() {
  const dummyImage =
    "https://handletheheat.com/wp-content/uploads/2017/03/Chewy-Brownies-Square-1.jpg";
  const dummyAuthor = "Comming soon";
  const recipes = await getRecipes();
  return (
    <main className="flex flex-auto gap-4 p-4">
      {recipes.data.map((recipe: Recipe) => (
        <Link href={`/${recipe.id}`} key={recipe.id}>
          <Card key={recipe.id} className="">
            <CardHeader>
              <CardTitle>{recipe.title}</CardTitle>
              <CardDescription>{recipe.description}</CardDescription>
            </CardHeader>
            <CardContent className="px-0">
              <Image
                src={dummyImage}
                alt={recipe.title}
                width={0}
                height={0}
                sizes="100vw"
                className="h-48 w-full"
              />
            </CardContent>
            <CardFooter>
              <CardDescription>Created by: {dummyAuthor}</CardDescription>
            </CardFooter>
          </Card>
        </Link>
      ))}
    </main>
  );
}
