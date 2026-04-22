namespace WorkoutGenerator.Domain;

public class Coach : ApplicationUser
{

    public List<Customer> Customers { get; set; } = new();
    public List<Workout> Workouts { get; set; } = new();
}