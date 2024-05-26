import "server-only";
import { IngredientResponse } from "@/lib/server/recipes";
import { getAccessToken } from "@auth0/nextjs-auth0";

export type PagedIngredientResponse = {
  data: IngredientResponse[];
  pageSize: number;
  pageNumber: number;
  previousPageNumber?: number;
  nextPageNumber?: number;
  totalRecords?: number;
};

export async function getAllIngredients(): Promise<PagedIngredientResponse> {
  const token = await getAccessToken();
  if (!token) {
    return { data: [], pageSize: 0, pageNumber: 0 };
  }

  try {
    const res = await fetch(`${process.env.API_PATH}ingredients`, {
      headers: {
        Authorization: `Bearer ${token.accessToken}`,
      },
    });

    return await res.json();
  } catch (error) {
    console.error(error);
    return {
      data: [],
      pageSize: 0,
      pageNumber: 0,
    };
  }
}
