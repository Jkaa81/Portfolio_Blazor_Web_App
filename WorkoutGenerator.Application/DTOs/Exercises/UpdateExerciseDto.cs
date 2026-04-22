namespace WorkoutGenerator.Application.DTOs.Exercises;

public class UpdateExerciseDto
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; } = string.Empty;
    public string ExerciseDescription { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public int DifficultyLevelId { get; set; }
}