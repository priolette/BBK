"use client";

import { Button } from "@/components/ui/button";
import { useUser } from "@auth0/nextjs-auth0/client";
import { Plus } from "lucide-react";
import Link from "next/link";

export function AddRecipeButton() {
  const { user } = useUser();

  if (!user) {
    return null;
  }

  return (
    <Button asChild>
      <Link href="/create" className="gap-2">
        <Plus /> <span>Create Recipe</span>
      </Link>
    </Button>
  );
}
