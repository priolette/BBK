"use server";

import { getAccessToken } from "@auth0/nextjs-auth0";
import { revalidatePath } from "next/cache";

export async function updateLike(recipeId: number) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to like a recipe.");
  }

  const res = await fetch(
    `${process.env.API_PATH}interactions/recipes/${recipeId}/upvote`,
    {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token.accessToken}`,
      },
    },
  );

  if (!res.ok) {
    throw new Error("Failed to update like.");
  }

  revalidatePath("/");
  revalidatePath(`/recipes/${recipeId}`);
}
