using WorkoutGenerator.Application.DTOs.Exercises;

namespace WorkoutGenerator.Application.Interfaces.Services;

public interface IExerciseService
{
    Task<List<ExerciseDto>> GetAllAsync();
    Task<ExerciseDto?> GetByIdAsync(int id);
    Task<ExerciseDto> AddAsync(CreateExerciseDto dto);
    Task UpdateAsync(UpdateExerciseDto dto);
    Task DeleteAsync(int id);
}