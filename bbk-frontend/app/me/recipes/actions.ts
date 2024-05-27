"use server";

import { ErrorResponse } from "@/lib/server/error";
import { getAccessToken } from "@auth0/nextjs-auth0";
import { revalidatePath } from "next/cache";

export async function deleteRecipe(recipeId: number) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to delete a recipe.");
  }

  const res = await fetch(`${process.env.API_PATH}user/recipes/${recipeId}`, {
    method: "DELETE",
    headers: {
      Authorization: `Bearer ${token.accessToken}`,
    },
  });

  if (!res.ok) {
    const error: ErrorResponse = await res.json();

    if (error.code === "NotFound") {
      throw new Error("Recipe not found.");
    } else if (error.code === "ConcurrencyError") {
      throw new Error("Recipe has been already deleted.");
    }

    throw new Error("Failed to delete recipe.");
  }

  revalidatePath("/me/recipes");
  revalidatePath("/");
}
