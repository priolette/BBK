import { UserResponse } from "@/lib/server/user";
import "server-only";

export type CommentResponse = {
  id: number;
  recipeId: number;
  createdById: string;
  createdBy?: UserResponse;
  createdAt: string;
  text: string;
};

export type CreateCommentRequest = {
  recipeId: number;
  text: string;
};
