namespace WorkoutGenerator.Application.DTOs.Workouts;

public class WorkoutDto
{
    public int WorkoutId { get; set; }

    public int CoachId { get; set; }
    public string CoachName { get; set; } = string.Empty;

    public int? CustomerId { get; set; }
    public string? CustomerName { get; set; }

    public string WorkoutTitle { get; set; } = string.Empty;
    public string? WorkoutDescription { get; set; }

    public bool IsTemplate { get; set; }
    public bool IsArchived { get; set; }

    public List<WorkoutExerciseDto> WorkoutExercises { get; set; } = new();
}