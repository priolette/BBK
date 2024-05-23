import "server-only";

type ShortRecipePagedResponse = {
  data: ShortRecipeResponse[];
  pageSize: number;
  pageNumber: number;
  previousPageNumber?: number;
  nextPageNumber?: number;
  total?: number;
};

type ShortRecipeResponse = {
  id: number;
  title?: string;
  description?: string;
  createdById?: string;
  createdAt: string;
  modifiedAt?: string;
  upvotes: number;
};

export async function getAllRecipes(
  currentPage: number,
  pageSize: number,
): Promise<ShortRecipePagedResponse> {
  try {
    const response = await fetch(
      `http://localhost:5101/api/v1/recipes?PageNumber=${currentPage}&PageSize=${pageSize}`,
    );

    return response.json();
  } catch (error) {
    console.error(error);
    return {
      data: [],
      pageSize: 0,
      pageNumber: 0,
      total: 0,
    };
  }
}
