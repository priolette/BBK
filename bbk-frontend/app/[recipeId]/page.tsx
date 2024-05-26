import { LikeButton } from "@/components/like-button";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { getRecipe } from "@/lib/server/recipes";
import { Pizza, User } from "lucide-react";
import Image from "next/image";
import { notFound } from "next/navigation";

export default async function Page({
  params,
}: {
  params: { recipeId: number };
}) {
  const recipeData = await getRecipe(params.recipeId);

  if (!recipeData) {
    notFound();
  }

  return (
    <div className="grid flex-1 gap-4 p-4 sm:grid-cols-2">
      <div className="flex justify-center">
        <aside className="flex flex-col items-center gap-4 sm:items-start">
          <div className="flex gap-2">
            <h1 className="gap-2 text-3xl font-bold">{recipeData.title}</h1>
            <LikeButton
              recipeId={recipeData.id}
              initialLikes={recipeData.upvotes}
              isLiked={recipeData.isUpvoted ?? false}
            />
          </div>

          {!!recipeData.imageUrl ? (
            <Image
              src={recipeData.imageUrl ?? ""}
              alt={recipeData.title}
              className="w-96 rounded-lg pb-4"
              width={150}
              height={100}
            />
          ) : (
            <Pizza className="h-24 w-24" />
          )}
          <p className="text-lg">{recipeData.description}</p>
          <span className="flex items-center gap-2">
            Created by:{" "}
            {!!recipeData.createdBy ? (
              <div className="flex items-center gap-2">
                <Avatar className="h-8 w-8">
                  <AvatarImage
                    src={recipeData.createdBy.picture ?? ""}
                    alt={recipeData.createdBy.nickName ?? ""}
                  />
                  <AvatarFallback>
                    <User />
                  </AvatarFallback>
                </Avatar>
                <span>{recipeData.createdBy.fullName}</span>
              </div>
            ) : (
              <></>
            )}
          </span>
        </aside>
      </div>
      <div className="flex h-full flex-col sm:pt-12">
        {/* Ingredients */}
        <div className="flex flex-col items-start">
          <h2 className="mb-2 text-2xl font-semibold">Ingredients:</h2>
          <ul className="ml-6 list-disc">
            {recipeData.ingredients.map((ingredient) => (
              <li key={ingredient.id} className="mb-1">
                {ingredient.amount} {ingredient.unit.code} of{" "}
                {ingredient.ingredient.name}
              </li>
            ))}
          </ul>
        </div>
        {/* Steps */}
        <div className="flex flex-col items-start">
          <h2 className="mb-2 mt-8 text-2xl font-semibold">Steps:</h2>
          <ol className="ml-6 list-decimal">
            {recipeData.steps.map((step) => (
              <li key={step.id} className="mb-1">
                {step.description}
              </li>
            ))}
          </ol>
        </div>
      </div>
      {/* Comments */}
      <div className="col-span-full flex justify-center">
        <div className="justify-start">
          <h2 className="item-start my-4 text-2xl font-semibold">Comments:</h2>
          {!recipeData.comments && (
            <div>
              <span>There are currently no comments for this recipe</span>
            </div>
          )}
          <ul className="ml-6 list-disc">
            {recipeData.comments.map((comment) => (
              <li key={comment.id} className="mb-1">
                {comment.text}
              </li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}
