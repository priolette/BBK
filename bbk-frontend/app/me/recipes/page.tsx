import { LikeButton } from "@/components/like-button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { getUserRecipes } from "@/lib/server/recipes";
import { Edit, Pizza } from "lucide-react";
import Link from "next/link";
import { notFound } from "next/navigation";
import Image from "next/image";
import { Button } from "@/components/ui/button";
import { DeleteButton } from "@/components/delete-button";

export default async function MyRecipesPage() {
  const data = await getUserRecipes();
  if (!data) {
    notFound();
  }

  return (
    <div>
      <h1 className="p-6 pb-2 text-4xl font-bold">My Recipes</h1>
      <div className="flex flex-wrap gap-4 p-4">
        {data.map((recipe) => (
          <Card key={recipe.id} className="mb-auto w-[400px] flex-col">
            <Link href={`/${recipe.id}`} key={recipe.id}>
              <CardHeader>
                <CardTitle>{recipe.title}</CardTitle>
                <CardDescription>{recipe.description}</CardDescription>
              </CardHeader>
              <CardContent className="px-0">
                {!!recipe.imageUrl ? (
                  <Image
                    src={recipe.imageUrl ?? ""}
                    alt={recipe.title}
                    className="w-full"
                    width={150}
                    height={100}
                  />
                ) : (
                  <Pizza className="h-24 w-24" />
                )}
              </CardContent>
            </Link>
            <CardFooter className="justify-between">
              <LikeButton
                recipeId={recipe.id}
                initialLikes={recipe.upvotes}
                isLiked={recipe.isUpvoted || false}
              />
              <div className="flex gap-2">
                <Button asChild size="icon" variant="secondary">
                  <Link href={`/me/recipes/${recipe.id}/edit`}>
                    <Edit />
                  </Link>
                </Button>
                <DeleteButton recipeId={recipe.id} />
              </div>
            </CardFooter>
          </Card>
        ))}
      </div>
    </div>
  );
}
