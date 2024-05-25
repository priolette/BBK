using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    private const string DefaultSchema = "public";

    private const string UtcNow = "now() at time zone 'utc'";

    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Step> Steps { get; init; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Upvote> Upvotes { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        ConfigureDataModels(modelBuilder);

        modelBuilder.SeedDatabase();
    }

    private static void ConfigureDataModels(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("Recipes", DefaultSchema);

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsRequired();

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(2048);

            entity.Property(e => e.CreatedById)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql(UtcNow)
                .IsRequired();
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.ToTable("Steps", DefaultSchema);

            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsRequired();

            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Steps)
                .HasForeignKey(e => e.RecipeId);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredients", DefaultSchema);

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(1024);
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.ToTable("RecipeIngredients", DefaultSchema);

            entity.Property(e => e.Amount)
                .IsRequired();

            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.RecipeIngredients)
                .HasForeignKey(e => e.RecipeId);

            entity.HasOne(e => e.Ingredient)
                .WithMany(e => e.IngredientAmounts)
                .HasForeignKey(e => e.IngredientId);

            entity.HasOne(e => e.Unit)
                .WithMany(e => e.IngredientAmounts)
                .HasForeignKey(e => e.UnitId);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Units", DefaultSchema);

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .IsRequired();
        });

        modelBuilder.Entity<Upvote>(entity =>
        {
            entity.ToTable("Upvotes", DefaultSchema);

            entity.HasKey(e => new { e.CreatedById, e.RecipeId });

            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Upvotes)
                .HasForeignKey(e => e.RecipeId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comments", DefaultSchema);
            
            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.RecipeId);

            entity.Property(e => e.CreatedById)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql(UtcNow)
                .IsRequired();

            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .IsRequired();

            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.RecipeId);
        });
    }
}
