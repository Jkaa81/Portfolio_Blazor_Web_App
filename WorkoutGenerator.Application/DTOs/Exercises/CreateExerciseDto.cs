using System.ComponentModel.DataAnnotations;

namespace WorkoutGenerator.Application.DTOs.Exercises;

public class CreateExerciseDto
{
    [Required(ErrorMessage = "Exercise name is required.")]
    [MaxLength(150)]
    public string ExerciseName { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string ExerciseDescription { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a difficulty level.")]
    public int DifficultyLevelId { get; set; }
}