import { z } from "zod";

export const CreateRecipeSchema = z.object({
  title: z.string().min(1, "Title cannot be empty").max(255),
  description: z.string().min(1, "Description cannot be empty").max(1024),
  imageUrl: z.string().min(1, "Recipe must have an image").max(2048),
  ingredients: z.array(
    z.object({
      amount: z
        .number()
        .or(z.string())
        .pipe(z.coerce.number().positive("Amount must be greater than 0")),
      ingredientId: z.number().min(1, "You must choose an ingredient"),
      unitId: z.number().min(1, "You must pick a measuring unit"),
    }),
  ),
  steps: z.array(
    z.object({
      description: z
        .string()
        .min(1, "Step description cannot be empty")
        .max(1024),
      order: z.number(),
    }),
  ),
});

export const CreateIngredientSchema = z.object({
  name: z.string().min(1, "Ingredient name cannot be empty").max(255),
  description: z.string().max(1024),
});

export const DeleteRecipeSchema = z.object({
  recipeId: z.number().min(1, "Invalid recipe ID"),
});

export const UpdateRecipeSchema = z.object({
  title: z.string().min(1, "Title cannot be empty").max(255),
  description: z.string().min(1, "Description cannot be empty").max(1024),
  imageUrl: z.string().min(1, "Recipe must have an image").max(2048),
  ingredients: z.array(
    z.object({
      amount: z
        .number()
        .or(z.string())
        .pipe(z.coerce.number().positive("Amount must be greater than 0")),
      ingredientId: z.number().min(1, "You must choose an ingredient"),
      unitId: z.number().min(1, "You must pick a measuring unit"),
    }),
  ),
  steps: z.array(
    z.object({
      description: z
        .string()
        .min(1, "Step description cannot be empty")
        .max(1024),
      order: z.number(),
    }),
  ),
});

export const CreateCommentSchema = z.object({
  recipeId: z.number().min(1, "Invalid recipe ID"),
  text: z.string().min(1, "Comment cannot be empty").max(1024),
});
