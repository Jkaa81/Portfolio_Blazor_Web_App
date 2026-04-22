using WorkoutGenerator.Application.DTOs.DifficultyLevels;

namespace WorkoutGenerator.Application.Interfaces.Services
{
    public interface IDifficultyLevelService
    {
        Task<List<DifficultyLevelDto>> GetAllAsync();
    }
}
