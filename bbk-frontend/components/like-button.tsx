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
  const [likedState, setLikedState] = useState(isLiked);
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
        if (!user) {
          return;
        }
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
