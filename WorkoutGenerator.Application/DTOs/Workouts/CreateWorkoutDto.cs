namespace WorkoutGenerator.Application.DTOs.Workouts;

public class CreateWorkoutDto
{
    public int CoachId { get; set; }
    public int? CustomerId { get; set; }

    public string WorkoutTitle { get; set; } = string.Empty;
    public string? WorkoutDescription { get; set; }

    public bool IsTemplate { get; set; }
    public bool IsArchived { get; set; }

    public List<CreateWorkoutExerciseDto> WorkoutExercises { get; set; } = new();
}