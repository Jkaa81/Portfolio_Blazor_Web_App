namespace WorkoutGenerator.Application.DTOs.Workouts;

public class WorkoutExerciseDto
{
    public int WorkoutExerciseId { get; set; }

    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;

    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public int Order { get; set; }
    public int? Duration { get; set; }
    public double? Weight { get; set; }
    public string? Notes { get; set; }
}