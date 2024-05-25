import "server-only";

type ShortRecipePagedResponse = {
  data: ShortRecipeResponse[];
  pageSize: number;
  pageNumber: number;
  previousPageNumber?: number;
  nextPageNumber?: number;
  totalRecords?: number;
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

type RecipeResponse = {
  id: number;
  title?: string;
  description?: string;
  createdById?: string;
  createdAt: string;
  modifiedAt?: string;
  ingredients: RecipeIngredientResponse[];
  steps: StepResponse[];
  upvotes: number;
  comments: CommentResponse[];
};

type RecipeIngredientResponse = {
  id: number;
  amount: number;
  ingredient: IngredientResponse;
  unit: UnitResponse;
};

type IngredientResponse = {
  id: number;
  name?: string;
  description?: string;
};

type UnitResponse = {
  id: number;
  name?: string;
  code?: string;
};

type StepResponse = {
  id: number;
  description?: string;
  order: number;
};

type CommentResponse = {
  id: number;
  recipeId: number;
  createdById?: string;
  createdAt: string;
  text?: string;
};

export async function getAllRecipes(
  currentPage: number,
  pageSize: number,
): Promise<ShortRecipePagedResponse> {
  try {
    const response = await fetch(
      `${process.env.API_PATH}recipes?PageNumber=${currentPage}&PageSize=${pageSize}`,
    );

    return response.json();
  } catch (error) {
    console.error(error);
    return {
      data: [],
      pageSize: 0,
      pageNumber: 0,
      totalRecords: 0,
    };
  }
}

export async function getRecipe(id: number): Promise<RecipeResponse | null> {
  try {
    const response = await fetch(`${process.env.API_PATH}recipes/${id}`);

    return response.json();
  } catch (error) {
    console.error(error);
    return null;
  }
}
