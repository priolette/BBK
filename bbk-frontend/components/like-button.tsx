"use client";

import { updateLike } from "@/app/actions";
import { Button } from "@/components/ui/button";
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
  const [likedState, setLikedState] = useOptimistic(isLiked, (state) => !state);
  const [optimisticLikes, addOptimisticLike] = useOptimistic(
    initialLikes,
    (state, action: "like" | "dislike") => {
      if (action === "like") {
        return state + 1;
      } else {
        return state - 1;
      }
    },
  );

  return (
    <Button
      className="gap-2 rounded-full"
      onClick={async () => {
        setLikedState(!likedState);
        addOptimisticLike(likedState ? "dislike" : "like");
        await updateLike(recipeId);
      }}
    >
      {likedState ? <Heart fill="white" /> : <Heart />}
      {optimisticLikes}
    </Button>
  );
}
