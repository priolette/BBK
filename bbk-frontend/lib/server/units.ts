import { UnitResponse } from "@/lib/server/recipes";
import { getAccessToken } from "@auth0/nextjs-auth0";
import "server-only";

export async function getAllUnits(): Promise<UnitResponse[]> {
  const token = await getAccessToken();
  if (!token) {
    throw new Error("You must be logged in to create a recipe.");
  }

  try {
    const res = await fetch(`${process.env.API_PATH}units`, {
      headers: {
        Authorization: `Bearer ${token.accessToken}`,
      },
    });

    return await res.json();
  } catch (error) {
    console.error(error);
    return [];
  }
}
