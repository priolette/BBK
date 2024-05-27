import type { Metadata } from "next";
import { Alkatra, Inter } from "next/font/google";
import "./globals.css";
import { ThemeProvider } from "@/components/theme-provider";
import { cn } from "@/lib/utils";
import { ThemeToggle } from "@/components/theme-toggle";
import Link from "next/link";
import { UserProvider } from "@auth0/nextjs-auth0/client";
import { LoginButton } from "@/components/login-button";
import { AddRecipeButton } from "@/components/add-recipe-button";
import { Toaster } from "@/components/ui/sonner";

const inter = Inter({ subsets: ["latin"], variable: "--font-sans" });
const alkatra = Alkatra({ subsets: ["latin"], variable: "--font-alkatra" });

export const metadata: Metadata = {
  title: "Recipify",
  description: "Recipe sharing platform",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <UserProvider>
        <body
          className={cn(
            "min-h-screen bg-background font-sans antialiased",
            inter.variable,
          )}
        >
          <ThemeProvider
            attribute="class"
            defaultTheme="system"
            enableSystem
            disableTransitionOnChange
          >
            <div className="grid h-screen grid-rows-[auto,1fr]">
              <NavBar />
              <main className="overflow-y-auto">{children}</main>
            </div>
            <Toaster />
          </ThemeProvider>
        </body>
      </UserProvider>
    </html>
  );
}

function NavBar() {
  return (
    <header className="flex w-full flex-row items-center gap-4 border-b p-4 text-xl font-semibold">
      <nav className="flex w-full items-center">
        <Link
          href={"/"}
          className={cn(
            "font-alkatra text-3xl font-extrabold",
            alkatra.variable,
          )}
        >
          Recipify
        </Link>
      </nav>
      <AddRecipeButton />
      <ThemeToggle />
      <LoginButton />
    </header>
  );
}
