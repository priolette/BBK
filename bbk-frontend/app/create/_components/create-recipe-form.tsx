"use client";

import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { IngredientResponse, UnitResponse } from "@/lib/server/recipes";
import { useFieldArray, useForm } from "react-hook-form";
import { CreateIngredientSchema, CreateRecipeSchema } from "@/lib/formSchemas";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
  CommandSeparator,
} from "@/components/ui/command";
import { Label } from "@/components/ui/label";
import { Plus, Trash } from "lucide-react";
import { useState } from "react";
import Link from "next/link";
import { createRecipe } from "@/app/create/actions";
import { toast } from "sonner";

export function CreateRecipeForm({
  ingredients,
  units,
}: {
  ingredients: IngredientResponse[];
  units: UnitResponse[];
}) {
  const recipeForm = useForm<z.infer<typeof CreateRecipeSchema>>({
    resolver: zodResolver(CreateRecipeSchema),
    defaultValues: {
      title: "",
      description: "",
      imageUrl: "",
      ingredients: [],
      steps: [],
    },
  });
  const {
    fields: ingredientFields,
    append: appendIngredient,
    remove: removeIngredient,
  } = useFieldArray({
    control: recipeForm.control,
    name: "ingredients",
  });
  const {
    fields: stepFields,
    append: appendStep,
    remove: removeStep,
  } = useFieldArray({
    control: recipeForm.control,
    name: "steps",
  });

  const onRecipeSubmit = async (values: z.infer<typeof CreateRecipeSchema>) => {
    try {
      await createRecipe(values);
    } catch (error) {
      if (error instanceof Error) {
        toast.error(error.message);
      } else {
        throw error;
      }
    }
  };

  return (
    <Form {...recipeForm}>
      <form
        onSubmit={recipeForm.handleSubmit(onRecipeSubmit)}
        className="space-y-4 p-4"
      >
        <FormField
          control={recipeForm.control}
          name="title"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Title</FormLabel>
              <FormControl>
                <Input placeholder="Your recipe title" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={recipeForm.control}
          name="description"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Description</FormLabel>
              <FormControl>
                <Textarea placeholder="Your recipe description" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={recipeForm.control}
          name="imageUrl"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Image URL</FormLabel>
              <FormControl>
                <Input placeholder="Your recipe image URL" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <div className="flex flex-col space-y-4">
          <Label className="space-y-9">Ingredients</Label>
          {ingredientFields.map((field, index) => (
            <div key={`ingredient_${field.id}`} className="flex flex-col">
              <Label className="pb-2">Ingredient {index + 1}:</Label>
              <div className="flex gap-2">
                <div className="flex-1">
                  <FormField
                    key={`ingredientId_${field.id}`}
                    control={recipeForm.control}
                    name={`ingredients.${index}.ingredientId`}
                    render={({ field }) => (
                      <FormItem className="relative">
                        <FormControl>
                          <Popover>
                            <PopoverTrigger asChild>
                              <Button
                                variant="outline"
                                role="combobox"
                                className="w-full"
                              >
                                {field.value
                                  ? ingredients.find(
                                      (i) => i.id === field.value,
                                    )?.name
                                  : "Choose Ingredient"}
                              </Button>
                            </PopoverTrigger>
                            <PopoverContent className="p-0">
                              <Command>
                                <CommandInput placeholder="Search ingredient..." />
                                <CommandList>
                                  <CommandEmpty>
                                    No ingredient found
                                  </CommandEmpty>
                                  <CommandGroup>
                                    <CommandItem asChild>
                                      <Link href={`/create/ingredient`}>
                                        <Plus />
                                        Add New Ingredient
                                      </Link>
                                    </CommandItem>
                                  </CommandGroup>
                                  <CommandSeparator />
                                  <CommandGroup>
                                    {ingredients.map((ingredient) => (
                                      <CommandItem
                                        key={ingredient.id}
                                        value={ingredient.name}
                                        onSelect={() => {
                                          recipeForm.setValue(
                                            `ingredients.${index}.ingredientId`,
                                            ingredient.id,
                                          );
                                        }}
                                        className="w-full"
                                      >
                                        {ingredient.name}
                                      </CommandItem>
                                    ))}
                                  </CommandGroup>
                                </CommandList>
                              </Command>
                            </PopoverContent>
                          </Popover>
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <div className="flex-1">
                  <FormField
                    key={`amount_${field.id}`}
                    control={recipeForm.control}
                    name={`ingredients.${index}.amount`}
                    render={({ field }) => (
                      <FormItem className="relative">
                        <FormControl>
                          <Input
                            placeholder="Amount"
                            className="w-full"
                            {...field}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <div className="flex-1">
                  <FormField
                    key={`unitId_${field.id}`}
                    control={recipeForm.control}
                    name={`ingredients.${index}.unitId`}
                    render={({ field }) => (
                      <FormItem className="relative">
                        <FormControl>
                          <Popover>
                            <PopoverTrigger asChild>
                              <Button
                                variant="outline"
                                role="combobox"
                                className="w-full"
                              >
                                {field.value
                                  ? units.find((u) => u.id === field.value)
                                      ?.name
                                  : "Choose Unit"}
                              </Button>
                            </PopoverTrigger>
                            <PopoverContent className="p-0">
                              <Command>
                                <CommandInput placeholder="Search unit..." />
                                <CommandList>
                                  <CommandEmpty>No unit found</CommandEmpty>
                                  <CommandGroup>
                                    {units.map((unit) => (
                                      <CommandItem
                                        key={unit.id}
                                        value={unit.name}
                                        onSelect={() => {
                                          recipeForm.setValue(
                                            `ingredients.${index}.unitId`,
                                            unit.id,
                                          );
                                        }}
                                      >
                                        {unit.name}
                                      </CommandItem>
                                    ))}
                                  </CommandGroup>
                                </CommandList>
                              </Command>
                            </PopoverContent>
                          </Popover>
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <Button
                  onClick={() => {
                    removeIngredient(index);
                  }}
                  variant="destructive"
                  size="icon"
                >
                  <Trash />
                </Button>
              </div>
            </div>
          ))}
          <Button
            onClick={() =>
              appendIngredient({
                amount: 0,
                ingredientId: 0,
                unitId: 0,
              })
            }
            type="button"
            className="max-w-min gap-2"
            variant="secondary"
          >
            <Plus />
            Add Ingredient
          </Button>
        </div>

        <div className="flex flex-col space-y-4">
          <Label className="space-y-9">Steps</Label>
          {stepFields.map((field, index) => (
            <div key={`step_${field.id}`} className="flex flex-col">
              <Label className="pb-2">Step {index + 1}:</Label>
              <div className="flex gap-2">
                <FormField
                  key={`description_${field.id}`}
                  control={recipeForm.control}
                  name={`steps.${index}.description`}
                  render={({ field }) => (
                    <FormItem className="w-full">
                      <FormControl>
                        <Textarea placeholder="Step description" {...field} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
                <Button
                  onClick={() => {
                    removeStep(index);
                  }}
                  variant="destructive"
                  size="icon"
                >
                  <Trash />
                </Button>
                <FormField
                  key={`order_${field.id}`}
                  control={recipeForm.control}
                  name={`steps.${index}.order`}
                  render={({ field }) => (
                    <FormItem hidden>
                      <FormControl>
                        <Input {...field} value={index + 1} />
                      </FormControl>
                      <FormMessage />
                    </FormItem>
                  )}
                />
              </div>
            </div>
          ))}
          <Button
            onClick={() =>
              appendStep({
                description: "",
                order: stepFields.length + 1,
              })
            }
            type="button"
            className="max-w-min gap-2"
            variant="secondary"
          >
            <Plus />
            Add Step
          </Button>
        </div>

        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
}
