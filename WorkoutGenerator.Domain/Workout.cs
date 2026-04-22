using System.ComponentModel.DataAnnotations;

namespace WorkoutGenerator.Domain;

public class Workout
{
    public int WorkoutId { get; set; }

    [Required]
    public Coach Coach { get; set; } = default!;
    public int CoachId { get; set; }
    public Customer? Customer { get; set; }
    public int? CustomerId { get; set; }

    public string WorkoutTitle { get; set; } = string.Empty;
    public string? WorkoutDescription { get; set; }

    public bool IsTemplate { get; set; }
    public bool IsArchived { get; set; }

    public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
}