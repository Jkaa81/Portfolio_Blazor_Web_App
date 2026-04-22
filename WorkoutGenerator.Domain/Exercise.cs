namespace WorkoutGenerator.Domain;

public class Exercise
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;
    public string ExerciseDescription { get; set; } = string.Empty;

    public Category Category { get; set; } = default!;
    public int CategoryId { get; set; }



    public DifficultyLevel DifficultyLevel { get; set; } = default!;
    public int DifficultyLevelId { get; set; }


}