"use client";

import { deleteRecipe } from "@/app/me/recipes/actions";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Form, FormControl, FormField, FormItem } from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { DeleteRecipeSchema } from "@/lib/formSchemas";
import { useUser } from "@auth0/nextjs-auth0/client";
import { zodResolver } from "@hookform/resolvers/zod";
import { Trash } from "lucide-react";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";

export function DeleteButton({ recipeId }: { recipeId: number }) {
  const { user } = useUser();

  const form = useForm<z.infer<typeof DeleteRecipeSchema>>({
    resolver: zodResolver(DeleteRecipeSchema),
    defaultValues: { recipeId },
  });

  const [open, setOpen] = useState(false);

  if (!user) {
    return null;
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button variant="destructive" size="icon">
          <Trash />
        </Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Delete recipe</DialogTitle>
        </DialogHeader>
        <DialogDescription>
          Are you sure you want to delete this recipe?
        </DialogDescription>
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(async (data) => {
              console.log(data);
              await deleteRecipe(data.recipeId);
              setOpen(false);
            })}
          >
            <FormField
              control={form.control}
              name="recipeId"
              render={({ field }) => (
                <FormItem>
                  <FormControl>
                    <Input {...field} type="hidden" />
                  </FormControl>
                </FormItem>
              )}
            />
            <Button variant="destructive" type="submit" className="w-full">
              Confirm
            </Button>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
