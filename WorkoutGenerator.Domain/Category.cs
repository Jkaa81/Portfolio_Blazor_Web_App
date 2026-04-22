namespace WorkoutGenerator.Domain;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public List<Exercise> Exercises { get; set; } = new();
}