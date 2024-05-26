"use client";

import { updateLike } from "@/app/actions";
import { Button } from "@/components/ui/button";
import { useUser } from "@auth0/nextjs-auth0/client";
import { Heart } from "lucide-react";
import { useOptimistic, useState } from "react";

export function LikeButton({
  recipeId,
  initialLikes,
  isLiked,
}: {
  recipeId: number;
  initialLikes: number;
  isLiked: boolean;
}) {
  const { user } = useUser();
  const [{ count, state }, addOptimisticLike] = useOptimistic(
    { count: initialLikes, state: isLiked },
    (state, action: "like" | "dislike") => {
      if (action === "like") {
        return { count: state.count + 1, state: true };
      } else {
        return { count: state.count - 1, state: false };
      }
    },
  );

  return (
    <Button
      className="gap-2"
      onClick={async () => {
        if (!user) {
          return;
        }
        addOptimisticLike(state ? "dislike" : "like");
        await updateLike(recipeId);
      }}
    >
      {state ? <Heart fill="white" /> : <Heart />}
      {count}
    </Button>
  );
}
