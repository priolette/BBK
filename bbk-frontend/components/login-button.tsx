"use client";

import { Button } from "@/components/ui/button";
import { useUser } from "@auth0/nextjs-auth0/client";

export function LoginButton() {
  const { user } = useUser();

  return (
    <Button asChild>
      {!!user ? (
        <a href="/api/auth/logout">Logout</a>
      ) : (
        <a href="/api/auth/login">Login</a>
      )}
    </Button>
  );
}
