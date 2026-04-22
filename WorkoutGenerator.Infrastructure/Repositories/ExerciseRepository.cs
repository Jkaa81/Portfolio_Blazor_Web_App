using Microsoft.EntityFrameworkCore;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Domain;
using WorkoutGenerator.Infrastructure.Data;

namespace WorkoutGenerator.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WorkoutContext _context;

    public ExerciseRepository(WorkoutContext context)
    {
        _context = context;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        return await _context.Exercises
            .Include(e => e.Category)
            .Include(e => e.DifficultyLevel)
            .ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _context.Exercises
            .Include(e => e.Category)
            .Include(e => e.DifficultyLevel)
            .FirstOrDefaultAsync(e => e.ExerciseId == id);
    }

    public async Task<Exercise> AddAsync(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        var existingExercise = await _context.Exercises
            .FirstOrDefaultAsync(e => e.ExerciseId == exercise.ExerciseId);

        if (existingExercise is null)
            throw new InvalidOperationException($"Exercise with id {exercise.ExerciseId} was not found.");

        existingExercise.ExerciseName = exercise.ExerciseName;
        existingExercise.ExerciseDescription = exercise.ExerciseDescription;
        existingExercise.CategoryId = exercise.CategoryId;
        existingExercise.DifficultyLevelId = exercise.DifficultyLevelId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        if (exercise is null)
            throw new InvalidOperationException($"Exercise with id {id} was not found.");

        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
    }
}