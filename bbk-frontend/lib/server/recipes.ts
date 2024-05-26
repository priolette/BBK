import { UserResponse } from "@/lib/server/user";
import { getAccessToken } from "@auth0/nextjs-auth0";
import "server-only";

export type ShortRecipePagedResponse = {
  data: ShortRecipeResponse[];
  pageSize: number;
  pageNumber: number;
  previousPageNumber?: number;
  nextPageNumber?: number;
  totalRecords?: number;
};

export type ShortRecipeResponse = {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
  createdById: string;
  createdBy?: UserResponse;
  createdAt: string;
  modifiedAt?: string;
  upvotes: number;
  isUpvoted?: boolean;
};

export type RecipeResponse = {
  id: number;
  title: string;
  description: string;
  imageUrl?: string;
  createdById: string;
  createdBy?: UserResponse;
  createdAt: string;
  modifiedAt?: string;
  ingredients: RecipeIngredientResponse[];
  steps: StepResponse[];
  upvotes: number;
  isUpvoted?: boolean;
  comments: CommentResponse[];
};

export type RecipeIngredientResponse = {
  id: number;
  amount: number;
  ingredient: IngredientResponse;
  unit: UnitResponse;
};

export type IngredientResponse = {
  id: number;
  name: string;
  description?: string;
};

export type UnitResponse = {
  id: number;
  name: string;
  code: string;
};

export type StepResponse = {
  id: number;
  description: string;
  order: number;
};

export type CommentResponse = {
  id: number;
  recipeId: number;
  createdById: string;
  createdAt: string;
  text: string;
};

export type CreateRecipeRequest = {
  title: string;
  description: string;
  imageUrl?: string;
  ingredients: CreateRecipeIngredientRequest[];
  steps: CreateStepRequest[];
};

export type CreateRecipeIngredientRequest = {
  ingredientId: number;
  unitId: number;
  amount: number;
};

export type CreateStepRequest = {
  description: string;
  order: number;
};

export async function getAllRecipes(
  currentPage: number,
  pageSize: number,
): Promise<ShortRecipePagedResponse> {
  let token;
  try {
    token = await getAccessToken();
  } catch (error) {}

  try {
    const response = await fetch(
      `${process.env.API_PATH}recipes?PageNumber=${currentPage}&PageSize=${pageSize}`,
      {
        headers: {
          Authorization: `Bearer ${token?.accessToken}`,
        },
      },
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

    if (!response.ok) {
      return null;
    }

    return response.json();
  } catch (error) {
    console.error(error);
    return null;
  }
}
