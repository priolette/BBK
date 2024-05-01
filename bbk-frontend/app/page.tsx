import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import Image from "next/image";
import { dummyRecipes } from "@/data/recipes";
import Link from "next/link";

export default function Home() {
  return (
    <main className="flex flex-auto gap-4 p-4">
      {dummyRecipes.map((recipe) => (
        <Link href={`/${recipe.id}`} key={recipe.id}>
          <Card key={recipe.id} className="">
            <CardHeader>
              <CardTitle>{recipe.name}</CardTitle>
              <CardDescription>{recipe.description}</CardDescription>
            </CardHeader>
            <CardContent className="px-0">
              <Image
                src={recipe.image}
                alt={recipe.name}
                width={0}
                height={0}
                sizes="100vw"
                className="h-48 w-full"
              />
            </CardContent>
            <CardFooter>
              <CardDescription>Created by: {recipe.author}</CardDescription>
            </CardFooter>
          </Card>
        </Link>
      ))}
    </main>
  );
}
