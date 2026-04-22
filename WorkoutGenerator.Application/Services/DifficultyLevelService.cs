using WorkoutGenerator.Application.DTOs.DifficultyLevels;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Application.Interfaces.Services;

namespace WorkoutGenerator.Application.Services;

public class DifficultyLevelService : IDifficultyLevelService
{
    private readonly IDifficultyLevelRepository _difficultyLevelRepository;

    public DifficultyLevelService(IDifficultyLevelRepository difficultyLevelRepository)
    {
        _difficultyLevelRepository = difficultyLevelRepository;
    }

    public async Task<List<DifficultyLevelDto>> GetAllAsync()
    {
        var levels = await _difficultyLevelRepository.GetAllAsync();

        return levels.Select(x => new DifficultyLevelDto
        {
            DifficultyLevelId = x.DifficultyLevelId,
            Name = x.Name
        }).ToList();
    }
}