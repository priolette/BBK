import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import Image from "next/image";
import { dummyImage } from "@/data/recipes";
import Link from "next/link";
import { getAllRecipes } from "@/lib/server/recipes";
import { RecipePagination } from "@/components/recipe-pagination";
import { notFound } from "next/navigation";
import { LikeButton } from "@/components/like-button";
import { Pizza } from "lucide-react";

export default async function Home({
  searchParams,
}: {
  searchParams?: { page?: number };
}) {
  const perPage = 9;
  const currentPage = searchParams?.page || 1;
  const res = await getAllRecipes(currentPage, perPage);

  if (res.data.length === 0 && currentPage > 1) {
    notFound();
  }

  return (
    <div className="flex flex-wrap gap-4 p-4">
      {res.data.map((recipe) => (
        <Card key={recipe.id} className="flex w-[400px] flex-col">
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
          <CardFooter className="flex h-full justify-between">
            <CardDescription>
              Created by: {recipe.createdBy?.fullName || "Unknown"}
            </CardDescription>
            <LikeButton
              recipeId={recipe.id}
              initialLikes={recipe.upvotes}
              isLiked={false}
            />
          </CardFooter>
        </Card>
      ))}
      <RecipePagination
        itemCount={res.totalRecords || 1}
        pageSize={perPage}
        currentPage={currentPage}
      />
    </div>
  );
}
