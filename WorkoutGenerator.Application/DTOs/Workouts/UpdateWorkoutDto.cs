namespace WorkoutGenerator.Application.DTOs.Workouts;

public class UpdateWorkoutDto
{
    public int WorkoutId { get; set; }

    public int CoachId { get; set; }
    public int? CustomerId { get; set; }

    public string WorkoutTitle { get; set; } = string.Empty;
    public string? WorkoutDescription { get; set; }

    public bool IsTemplate { get; set; }
    public bool IsArchived { get; set; }

    public List<UpdateWorkoutExerciseDto> WorkoutExercises { get; set; } = new();

}