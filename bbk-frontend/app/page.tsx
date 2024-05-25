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
import { dummyImage } from "@/data/recipes";
import Link from "next/link";
import { getAllRecipes } from "@/lib/server/recipes";
import { RecipePagination } from "@/components/recipe-pagination";
import { notFound } from "next/navigation";

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
        <Link href={`/${recipe.id}`} key={recipe.id}>
          <Card className="w-[400px]">
            <CardHeader>
              <CardTitle>{recipe.title}</CardTitle>
              <CardDescription>{recipe.description}</CardDescription>
            </CardHeader>
            <CardContent className="px-0">
              <Image
                src={dummyImage}
                alt={`${recipe.title} image`}
                height={100}
                width={150}
                className="w-full"
              />
            </CardContent>
            <CardFooter>
              <CardDescription>
                Created by: {recipe.createdById}
              </CardDescription>
            </CardFooter>
          </Card>
        </Link>
      ))}
      <RecipePagination
        itemCount={res.totalRecords || 1}
        pageSize={perPage}
        currentPage={currentPage}
      />
    </div>
  );
}
