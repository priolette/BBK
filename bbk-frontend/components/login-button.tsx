"use client";

import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { useUser } from "@auth0/nextjs-auth0/client";
import { CookingPot, LogOut, User } from "lucide-react";
import Link from "next/link";

export function LoginButton() {
  const { user } = useUser();

  return (
    <>
      {!!user ? (
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button
              variant="outline"
              size="lg"
              className="justify-between gap-2 px-2"
            >
              <Avatar className="h-8 w-8">
                <AvatarImage
                  src={user.picture ?? ""}
                  alt={user.nickname ?? ""}
                />
                <AvatarFallback>
                  <User />
                </AvatarFallback>
              </Avatar>
              <span className="font-semibold">{user.name}</span>
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuItem asChild className="hover:cursor-pointer">
              <Link href="/me/recipes">
                <CookingPot className="mr-2 h-4 w-4" />
                My Recipes
              </Link>
            </DropdownMenuItem>
            <DropdownMenuItem asChild className="hover:cursor-pointer">
              <a href="/api/auth/logout" className="flex items-center">
                <LogOut className="mr-2 h-4 w-4" />
                Log out
              </a>
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      ) : (
        <Button asChild>
          <a href="/api/auth/login">Log in</a>
        </Button>
      )}
    </>
  );
}
