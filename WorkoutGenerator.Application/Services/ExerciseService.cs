using WorkoutGenerator.Application.DTOs.Exercises;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Application.Interfaces.Services;
using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<List<ExerciseDto>> GetAllAsync()
    {
        var exercises = await _exerciseRepository.GetAllAsync();

        return exercises.Select(MapToDto).ToList();
    }

    public async Task<ExerciseDto?> GetByIdAsync(int id)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id);
        return exercise is null ? null : MapToDto(exercise);
    }

    public async Task<ExerciseDto> AddAsync(CreateExerciseDto dto)
    {
        var exercise = new Exercise
        {
            ExerciseName = dto.ExerciseName,
            ExerciseDescription = dto.ExerciseDescription,
            CategoryId = dto.CategoryId,
            DifficultyLevelId = dto.DifficultyLevelId
        };

        var created = await _exerciseRepository.AddAsync(exercise);
        var fullExercise = await _exerciseRepository.GetByIdAsync(created.ExerciseId);

        return MapToDto(fullExercise!);
    }

    public async Task UpdateAsync(UpdateExerciseDto dto)
    {
        var exercise = new Exercise
        {
            ExerciseId = dto.ExerciseId,
            ExerciseName = dto.ExerciseName,
            ExerciseDescription = dto.ExerciseDescription,
            CategoryId = dto.CategoryId,
            DifficultyLevelId = dto.DifficultyLevelId
        };

        await _exerciseRepository.UpdateAsync(exercise);
    }

    public Task DeleteAsync(int id)
        => _exerciseRepository.DeleteAsync(id);

    private static ExerciseDto MapToDto(Exercise exercise)
    {
        return new ExerciseDto
        {
            ExerciseId = exercise.ExerciseId,
            ExerciseName = exercise.ExerciseName,
            ExerciseDescription = exercise.ExerciseDescription,
            CategoryId = exercise.CategoryId,
            CategoryName = exercise.Category?.CategoryName ?? string.Empty,
            DifficultyLevelId = exercise.DifficultyLevelId,
            DifficultyLevelName = exercise.DifficultyLevel?.Name ?? string.Empty
        };
    }
}