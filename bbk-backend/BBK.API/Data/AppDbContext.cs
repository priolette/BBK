using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    private const string DefaultSchema = "public";

    private const string UtcNow = "now() at time zone 'utc'";

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureDataModels(modelBuilder);
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
                .WithMany()
                .HasForeignKey(e => e.RecipeId);

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

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredients", DefaultSchema);

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Amount)
                .IsRequired();

            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.RecipeId);

            entity.HasOne(e => e.Step)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.StepId);

            entity.HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId);
        });

        modelBuilder.Entity<Upvote>(entity =>
        {
            entity.ToTable("Upvotes", DefaultSchema);

            entity.HasKey(e => new { e.CreatedById, e.RecipeId });

            entity.HasOne(e => e.Recipe)
                .WithMany()
                .HasForeignKey(e => e.RecipeId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
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
        });
    }
}
