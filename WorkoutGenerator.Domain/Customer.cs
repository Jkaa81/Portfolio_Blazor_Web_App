namespace WorkoutGenerator.Domain;

public class Customer : ApplicationUser
{
    public Coach Coach { get; set; } = default!;
    public int CoachId { get; set; }

    public List<Workout> Workouts { get; set; } = new();
}