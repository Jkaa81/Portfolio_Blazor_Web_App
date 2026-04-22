using Microsoft.EntityFrameworkCore;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Domain;
using WorkoutGenerator.Infrastructure.Data;

namespace WorkoutGenerator.Infrastructure.Repositories;

public class DifficultyLevelRepository : IDifficultyLevelRepository
{
    private readonly WorkoutContext _context;

    public DifficultyLevelRepository(WorkoutContext context)
    {
        _context = context;
    }

    public async Task<List<DifficultyLevel>> GetAllAsync()
    {
        return await _context.DifficultyLevels.ToListAsync();
    }
}