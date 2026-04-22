namespace WorkoutGenerator.Domain;

public class DifficultyLevel
{
    public int DifficultyLevelId { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Exercise> Exercises { get; set; } = new();
}