import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import Image from "next/image";

const dummyRecipes = [
  {
    id: 1,
    name: "Pumpkin Pie",
    description: "A delicious pumpkin pie recipe",
    ingredients: ["1 sugar pumpkin", "1 pie crust"],
    steps: [
      "Cut the pumpkin in half",
      "Bake the pumpkin",
      "Mix the pumpkin with sugar",
      "Bake the pie",
    ],
    author: "Alice",
    image:
      "https://www.allrecipes.com/thmb/CQrgVw7qjs2QQfKqy0GMerfppsM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/229932-Simple-Pumpkin-Pie-vat-hero-4x3-LSH-ae211272471a4e7aa9f10716cdcf4bc3.jpg",
  },
  {
    id: 2,
    name: "Brownies",
    description: "A delicious brownie recipe",
    steps: [
      "Cut the pumpkin in half",
      "Bake the pumpkin",
      "Mix the pumpkin with sugar",
      "Bake the pie",
    ],
    author: "Alice",
    image:
      "https://handletheheat.com/wp-content/uploads/2017/03/Chewy-Brownies-Square-1.jpg",
  },
];

export default function Home() {
  return (
    <main className="flex flex-auto gap-4 p-4">
      {dummyRecipes.map((recipe) => (
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
      ))}
    </main>
  );
}
