using WorkoutGenerator.Domain;

public class WorkoutExercise
{
    public int WorkoutExerciseId { get; set; }

    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = default!;

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = default!;

    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public int Order { get; set; }
    public int? Duration { get; set; }
    public double? Weight { get; set; }
    public string? Notes { get; set; }
}