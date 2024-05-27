"use client";

import { createComment } from "@/app/[recipeId]/actions";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
} from "@/components/ui/form";
import { Textarea } from "@/components/ui/textarea";
import { CreateCommentSchema } from "@/lib/formSchemas";
import { useUser } from "@auth0/nextjs-auth0/client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { toast } from "sonner";
import { z } from "zod";

export function CreateCommentForm({ recipeId }: { recipeId: number }) {
  const { user } = useUser();

  const form = useForm<z.infer<typeof CreateCommentSchema>>({
    resolver: zodResolver(CreateCommentSchema),
    defaultValues: {
      recipeId,
      text: "",
    },
  });

  if (!user) {
    return null;
  }

  return (
    <Card>
      <CardHeader>
        <span className="font-semibold">Add Comment</span>
      </CardHeader>
      <CardContent>
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(async (data) => {
              try {
                await createComment(data);
                form.reset({ recipeId, text: "" });
              } catch (error) {
                if (error instanceof Error) {
                  toast.error(error.message);
                } else {
                  throw error;
                }
              }
            })}
            className="flex flex-col gap-4"
          >
            <FormField
              control={form.control}
              name="text"
              render={({ field }) => (
                <FormItem>
                  <FormControl>
                    <Textarea
                      {...field}
                      placeholder="Add a comment..."
                      className="w-full"
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <Button type="submit">Submit</Button>
          </form>
        </Form>
      </CardContent>
    </Card>
  );
}
