"use server";

import { CreateIngredientSchema, CreateRecipeSchema } from "@/lib/formSchemas";
import { ErrorResponse } from "@/lib/server/error";
import { getAccessToken } from "@auth0/nextjs-auth0";
import { revalidatePath } from "next/cache";
import { redirect } from "next/navigation";
import { z } from "zod";

export async function createRecipe(
  formData: z.infer<typeof CreateRecipeSchema>,
) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to create a recipe.");
  }

  const res = await fetch(`${process.env.API_PATH}user/recipes`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token.accessToken}`,
    },
    body: JSON.stringify(formData),
  });

  if (!res.ok) {
    throw new Error("Failed to create recipe.");
  }

  revalidatePath("/");
  redirect("/");
}

export async function createIngredient(
  formData: z.infer<typeof CreateIngredientSchema>,
) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to create an ingredient.");
  }

  const res = await fetch(`${process.env.API_PATH}ingredients`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token.accessToken}`,
    },
    body: JSON.stringify(formData),
  });

  if (!res.ok) {
    const data: ErrorResponse = await res.json();
    return { message: null, error: data.message };
  }

  revalidatePath("/create");
  redirect("/create");
}

export async function updateRecipe(
  formData: z.infer<typeof CreateRecipeSchema>,
  recipeId: number,
) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to update a recipe.");
  }

  const res = await fetch(`${process.env.API_PATH}user/recipes/${recipeId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token.accessToken}`,
    },
    body: JSON.stringify(formData),
  });

  if (!res.ok) {
    throw new Error("Failed to update recipe.");
  }

  revalidatePath("/me/recipes");
  redirect("/me/recipes");
}
