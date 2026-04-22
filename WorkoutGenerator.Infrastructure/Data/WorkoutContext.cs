using Microsoft.EntityFrameworkCore;
using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Infrastructure.Data;

public class WorkoutContext : DbContext
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options)
        : base(options)
    {
    }

    public DbSet<Coach> Coaches => Set<Coach>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<DifficultyLevel> DifficultyLevels => Set<DifficultyLevel>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Coach>()
            .HasBaseType<ApplicationUser>();

        modelBuilder.Entity<Customer>()
            .HasBaseType<ApplicationUser>();

        modelBuilder.Entity<Category>()
            .HasKey(x => x.CategoryId);

        modelBuilder.Entity<DifficultyLevel>()
            .HasKey(x => x.DifficultyLevelId);

        modelBuilder.Entity<Exercise>()
            .HasKey(x => x.ExerciseId);

        modelBuilder.Entity<Workout>()
            .HasKey(x => x.WorkoutId);

        modelBuilder.Entity<WorkoutExercise>()
    .HasKey(x => x.WorkoutExerciseId);

        modelBuilder.Entity<Category>()
            .Property(x => x.CategoryName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<DifficultyLevel>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Exercise>()
            .Property(x => x.ExerciseName)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Exercise>()
            .Property(x => x.ExerciseDescription)
            .HasMaxLength(2000);

        modelBuilder.Entity<Workout>()
            .Property(x => x.WorkoutTitle)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Workout>()
            .Property(x => x.WorkoutDescription)
            .HasMaxLength(2000);

        modelBuilder.Entity<WorkoutExercise>()
            .Property(x => x.Notes)
            .HasMaxLength(1000);

        modelBuilder.Entity<Exercise>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Exercise>()
            .HasOne(x => x.DifficultyLevel)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.DifficultyLevelId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Workout>()
            .HasOne(w => w.Coach)
            .WithMany(c => c.Workouts)
            .HasForeignKey(w => w.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Workout>()
            .HasOne(w => w.Customer)
            .WithMany(c => c.Workouts)
            .HasForeignKey(w => w.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(x => x.Workout)
            .WithMany(x => x.WorkoutExercises)
            .HasForeignKey(x => x.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(x => x.Exercise)
            .WithMany()
            .HasForeignKey(x => x.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Coach)
            .WithMany(c => c.Customers)
            .HasForeignKey(c => c.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Strength" },
            new Category { CategoryId = 2, CategoryName = "Cardio" }
        );

        // Difficulty levels
        modelBuilder.Entity<DifficultyLevel>().HasData(
            new DifficultyLevel { DifficultyLevelId = 1, Name = "Beginner" },
            new DifficultyLevel { DifficultyLevelId = 2, Name = "Intermediate" },
            new DifficultyLevel { DifficultyLevelId = 3, Name = "Advanced" }
        );

        // Exercises
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise
            {
                ExerciseId = 1,
                ExerciseName = "Bench Press",
                ExerciseDescription = "Chest exercise with barbell",
                CategoryId = 1,
                DifficultyLevelId = 2
            },
            new Exercise
            {
                ExerciseId = 2,
                ExerciseName = "Squat",
                ExerciseDescription = "Leg exercise with barbell",
                CategoryId = 1,
                DifficultyLevelId = 2
            },
            new Exercise
            {
                ExerciseId = 3,
                ExerciseName = "Plank",
                ExerciseDescription = "Core stability exercise",
                CategoryId = 2,
                DifficultyLevelId = 1
            }
        );

        // Coach
        modelBuilder.Entity<Coach>().HasData(
            new Coach
            {
                Id = 1,
                Name = "Coach Mike",
                Phone = "12345678"
            }
        );

        // Customer
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 2,
                Name = "John Doe",
                Phone = "87654321",
                CoachId = 1
            }
        );

        // Workout
        modelBuilder.Entity<Workout>().HasData(
            new Workout
            {
                WorkoutId = 1,
                WorkoutTitle = "Full Body Beginner",
                WorkoutDescription = "Simple beginner workout",
                CoachId = 1,
                CustomerId = 2,
                IsTemplate = false,
                IsArchived = false
            }
        );

        // WorkoutExercises
        modelBuilder.Entity<WorkoutExercise>().HasData(
            new WorkoutExercise
            {
                WorkoutExerciseId = 1,
                WorkoutId = 1,
                ExerciseId = 1,
                Sets = 3,
                Reps = 10,
                Order = 1
            },
            new WorkoutExercise
            {
                WorkoutExerciseId = 2,
                WorkoutId = 1,
                ExerciseId = 2,
                Sets = 3,
                Reps = 8,
                Order = 2
            },
            new WorkoutExercise
            {
                WorkoutExerciseId = 3,
                WorkoutId = 1,
                ExerciseId = 3,
                Duration = 60,
                Order = 3
            }
        );
    }
}