"use server";

import { revalidatePath } from "next/cache";

export async function updateLike(recipeId: number) {
  revalidatePath("/");
  return null;
}
