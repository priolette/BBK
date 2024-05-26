"use server";

import { CreateCommentRequest } from "@/lib/server/comments";
import { getAccessToken } from "@auth0/nextjs-auth0";
import { revalidatePath } from "next/cache";

export async function createComment(comment: CreateCommentRequest) {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("Unauthorized");
  }

  try {
    const response = await fetch(
      `${process.env.API_PATH}interactions/comments`,
      {
        method: "POST",
        headers: {
          Authorization: `Bearer ${token.accessToken}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify(comment),
      },
    );

    if (!response.ok) {
      throw new Error("Failed to create comment");
    }
  } catch (error) {
    console.error(error);
  }

  revalidatePath("/");
}
