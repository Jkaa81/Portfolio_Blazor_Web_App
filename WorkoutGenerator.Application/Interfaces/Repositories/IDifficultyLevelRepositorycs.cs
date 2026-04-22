using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Application.Interfaces.Repositories;

public interface IDifficultyLevelRepository
{
    Task<List<DifficultyLevel>> GetAllAsync();
}