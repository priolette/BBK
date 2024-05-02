import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import { ThemeProvider } from "@/components/theme-provider";
import { cn } from "@/lib/utils";
import { ThemeToggle } from "@/components/theme-toggle";
import Link from "next/link";
import { UserProvider } from "@auth0/nextjs-auth0/client";
import { LoginButton } from "@/components/login-button";

const inter = Inter({ subsets: ["latin"], variable: "--font-sans" });

export const metadata: Metadata = {
  title: "Recipes",
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
              <main className="overflow-y-scroll">{children}</main>
            </div>
          </ThemeProvider>
        </body>
      </UserProvider>
    </html>
  );
}

function NavBar() {
  return (
    <header className="flex w-full flex-row items-center gap-4 border-b p-4 text-xl font-semibold">
      <nav className="ml-auto flex w-full items-center">
        <Link href={"/"}>Recipes</Link>
      </nav>
      <ThemeToggle />
      <LoginButton />
    </header>
  );
}
