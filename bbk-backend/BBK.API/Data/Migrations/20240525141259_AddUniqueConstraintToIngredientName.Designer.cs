﻿// <auto-generated />
using System;
using BBK.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BBK.API.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240525141259_AddUniqueConstraintToIngredientName")]
    partial class AddUniqueConstraintToIngredientName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BBK.API.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Comments", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 25, 14, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedById = "google-oauth2|103919914105442701060",
                            RecipeId = 1,
                            Text = "This pumpkin bread is delicious! I added some chocolate chips for extra sweetness."
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 23, 14, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedById = "auth0|662e3bad87766e08b83e46a0",
                            RecipeId = 1,
                            Text = "I made this for Thanksgiving and it was a hit with my family. Will definitely make again!"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 25, 0, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedById = "google-oauth2|103919914105442701060",
                            RecipeId = 2,
                            Text = "The pumpkin pie turned out perfectly. I used a store-bought crust to save time."
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 25, 14, 7, 59, 52, DateTimeKind.Unspecified).AddTicks(8586), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedById = "auth0|662e3bad87766e08b83e46a0",
                            RecipeId = 2,
                            Text = "I love pumpkin pie and this recipe did not disappoint. The spices were just right!"
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "White, all-purpose",
                            Name = "Flour"
                        },
                        new
                        {
                            Id = 2,
                            Description = "White, granulated",
                            Name = "Sugar"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Table salt",
                            Name = "Salt"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Unsalted",
                            Name = "Butter"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Large, whole",
                            Name = "Egg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Whole",
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Double-acting",
                            Name = "Baking Powder"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Pure",
                            Name = "Vanilla Extract"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Ground",
                            Name = "Cinnamon"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Ground",
                            Name = "Nutmeg"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Ground",
                            Name = "Cloves"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Ground",
                            Name = "Ginger"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Canned, puree",
                            Name = "Pumpkin"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Chopped",
                            Name = "Pecans"
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Recipes", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 25, 17, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedById = "google-oauth2|103919914105442701060",
                            Description = "A delicious, moist pumpkin bread with a hint of spice.",
                            ImageUrl = "https://www.onceuponachef.com/images/2009/09/Pumpkin-Bread-100.jpg",
                            Title = "Pumpkin Bread"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 5, 25, 17, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedById = "auth0|662e3bad87766e08b83e46a0",
                            Description = "A classic pumpkin pie with a flaky crust and creamy filling.",
                            ImageUrl = "https://www.allrecipes.com/thmb/CQrgVw7qjs2QQfKqy0GMerfppsM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/229932-Simple-Pumpkin-Pie-vat-hero-4x3-LSH-ae211272471a4e7aa9f10716cdcf4bc3.jpg",
                            Title = "Pumpkin Pie"
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UnitId");

                    b.ToTable("RecipeIngredients", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2.0,
                            IngredientId = 1,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1.5,
                            IngredientId = 2,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1.0,
                            IngredientId = 3,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 4,
                            Amount = 0.5,
                            IngredientId = 4,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 5,
                            Amount = 2.0,
                            IngredientId = 5,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 0.5,
                            IngredientId = 6,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 7,
                            Amount = 1.0,
                            IngredientId = 7,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 8,
                            Amount = 1.0,
                            IngredientId = 8,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 9,
                            Amount = 1.0,
                            IngredientId = 9,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 10,
                            Amount = 0.5,
                            IngredientId = 10,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 11,
                            Amount = 0.25,
                            IngredientId = 11,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 12,
                            Amount = 0.25,
                            IngredientId = 12,
                            RecipeId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 13,
                            Amount = 1.0,
                            IngredientId = 13,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 14,
                            Amount = 0.5,
                            IngredientId = 14,
                            RecipeId = 1,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 15,
                            Amount = 1.0,
                            IngredientId = 1,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 16,
                            Amount = 0.75,
                            IngredientId = 2,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 28,
                            Amount = 0.5,
                            IngredientId = 3,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 17,
                            Amount = 0.25,
                            IngredientId = 4,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 18,
                            Amount = 2.0,
                            IngredientId = 5,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 19,
                            Amount = 1.0,
                            IngredientId = 6,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 20,
                            Amount = 1.0,
                            IngredientId = 7,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 21,
                            Amount = 1.0,
                            IngredientId = 8,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 22,
                            Amount = 1.0,
                            IngredientId = 9,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 23,
                            Amount = 0.5,
                            IngredientId = 10,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 24,
                            Amount = 0.25,
                            IngredientId = 11,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 25,
                            Amount = 0.25,
                            IngredientId = 12,
                            RecipeId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            Id = 26,
                            Amount = 1.0,
                            IngredientId = 13,
                            RecipeId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            Id = 27,
                            Amount = 0.5,
                            IngredientId = 14,
                            RecipeId = 2,
                            UnitId = 1
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Preheat oven to 350°F.",
                            Order = 1,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Grease and flour a 9x5-inch loaf pan.",
                            Order = 2,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "In a medium bowl, whisk together flour, sugar, salt, and baking powder.",
                            Order = 3,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "In a large bowl, beat butter, eggs, milk, and vanilla until smooth.",
                            Order = 4,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Gradually add dry ingredients to wet ingredients, mixing until just combined.",
                            Order = 5,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Fold in pumpkin, pecans, and spices.",
                            Order = 6,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Pour batter into prepared pan and smooth the top.",
                            Order = 7,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Description = "Bake for 60-70 minutes, or until a toothpick inserted into the center comes out clean.",
                            Order = 8,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 9,
                            Description = "Cool in pan for 10 minutes, then transfer to a wire rack to cool completely.",
                            Order = 9,
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 10,
                            Description = "Preheat oven to 425°F.",
                            Order = 1,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 11,
                            Description = "Fit pie crust into a 9-inch pie plate and crimp edges as desired.",
                            Order = 2,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 12,
                            Description = "In a large bowl, whisk together pumpkin, sugar, salt, and spices.",
                            Order = 3,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 13,
                            Description = "In a separate bowl, whisk together eggs and milk.",
                            Order = 4,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 14,
                            Description = "Gradually add egg mixture to pumpkin mixture, whisking until smooth.",
                            Order = 5,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 15,
                            Description = "Pour filling into pie crust and smooth the top.",
                            Order = 6,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 16,
                            Description = "Bake for 15 minutes, then reduce oven temperature to 350°F and bake for an additional 40-50 minutes, or until filling is set.",
                            Order = 7,
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 17,
                            Description = "Cool on a wire rack for 2 hours, then refrigerate until ready to serve.",
                            Order = 8,
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Units", "public");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "C",
                            Name = "Cup"
                        },
                        new
                        {
                            Id = 2,
                            Code = "Tbsp",
                            Name = "Tablespoon"
                        },
                        new
                        {
                            Id = 3,
                            Code = "Tsp",
                            Name = "Teaspoon"
                        },
                        new
                        {
                            Id = 4,
                            Code = "Oz",
                            Name = "Ounce"
                        },
                        new
                        {
                            Id = 5,
                            Code = "Lb",
                            Name = "Pound"
                        },
                        new
                        {
                            Id = 6,
                            Code = "g",
                            Name = "Gram"
                        },
                        new
                        {
                            Id = 7,
                            Code = "kg",
                            Name = "Kilogram"
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Upvote", b =>
                {
                    b.Property<string>("CreatedById")
                        .HasColumnType("text");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("CreatedById", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Upvotes", "public");

                    b.HasData(
                        new
                        {
                            CreatedById = "google-oauth2|103919914105442701060",
                            RecipeId = 1
                        },
                        new
                        {
                            CreatedById = "auth0|662e3bad87766e08b83e46a0",
                            RecipeId = 1
                        },
                        new
                        {
                            CreatedById = "google-oauth2|103919914105442701060",
                            RecipeId = 2
                        },
                        new
                        {
                            CreatedById = "auth0|662e3bad87766e08b83e46a0",
                            RecipeId = 2
                        },
                        new
                        {
                            CreatedById = "TestUser3",
                            RecipeId = 2
                        },
                        new
                        {
                            CreatedById = "TestUser4",
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("BBK.API.Data.Models.Comment", b =>
                {
                    b.HasOne("BBK.API.Data.Models.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BBK.API.Data.Models.RecipeIngredient", b =>
                {
                    b.HasOne("BBK.API.Data.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBK.API.Data.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BBK.API.Data.Models.Unit", "Unit")
                        .WithMany("IngredientAmounts")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("BBK.API.Data.Models.Step", b =>
                {
                    b.HasOne("BBK.API.Data.Models.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BBK.API.Data.Models.Upvote", b =>
                {
                    b.HasOne("BBK.API.Data.Models.Recipe", "Recipe")
                        .WithMany("Upvotes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BBK.API.Data.Models.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("BBK.API.Data.Models.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("RecipeIngredients");

                    b.Navigation("Steps");

                    b.Navigation("Upvotes");
                });

            modelBuilder.Entity("BBK.API.Data.Models.Unit", b =>
                {
                    b.Navigation("IngredientAmounts");
                });
#pragma warning restore 612, 618
        }
    }
}
