namespace WorkoutGenerator.Application.DTOs.Exercises;

public class ExerciseDto
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;
    public string ExerciseDescription { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public int DifficultyLevelId { get; set; }
    public string DifficultyLevelName { get; set; } = string.Empty;
}