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

export default async function Home({
  searchParams,
}: {
  searchParams?: { page?: number };
}) {
  const perPage = 10;
  const currentPage = searchParams?.page || 1;
  const data = await getAllRecipes(currentPage, perPage);

  return (
    <main className="flex flex-auto gap-4 p-4">
      {data.data.map((recipe) => (
        <Link href={`/${recipe.id}`} key={recipe.id}>
          <Card key={recipe.id} className="">
            <CardHeader>
              <CardTitle>{recipe.title}</CardTitle>
              <CardDescription>{recipe.description}</CardDescription>
            </CardHeader>
            <CardContent className="px-0">
              <Image
                src={dummyImage}
                alt={dummyImage}
                width={0}
                height={0}
                sizes="100vw"
                className="h-48 w-full"
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
        itemCount={data.total || 1}
        pageSize={perPage}
        currentPage={currentPage}
      />
    </main>
  );
}
