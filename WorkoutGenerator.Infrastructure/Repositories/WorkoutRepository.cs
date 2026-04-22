using Microsoft.EntityFrameworkCore;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Domain;
using WorkoutGenerator.Infrastructure.Data;

namespace WorkoutGenerator.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly WorkoutContext _context;

    public WorkoutRepository(WorkoutContext context)
    {
        _context = context;
    }

    public async Task<List<Workout>> GetAllAsync()
    {
        return await _context.Workouts
            .Include(w => w.Coach)
            .Include(w => w.Customer)
            .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
            .ToListAsync();
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        return await _context.Workouts
            .Include(w => w.Coach)
            .Include(w => w.Customer)
            .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
            .FirstOrDefaultAsync(w => w.WorkoutId == id);
    }

    public async Task<Workout> AddAsync(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return workout;
    }

    public async Task UpdateAsync(Workout workout)
    {
        var existingWorkout = await _context.Workouts
            .Include(w => w.WorkoutExercises)
            .FirstOrDefaultAsync(w => w.WorkoutId == workout.WorkoutId);

        if (existingWorkout is null)
            throw new InvalidOperationException($"Workout with id {workout.WorkoutId} was not found.");

        existingWorkout.WorkoutTitle = workout.WorkoutTitle;
        existingWorkout.WorkoutDescription = workout.WorkoutDescription;
        existingWorkout.CoachId = workout.CoachId;
        existingWorkout.CustomerId = workout.CustomerId;
        existingWorkout.IsTemplate = workout.IsTemplate;
        existingWorkout.IsArchived = workout.IsArchived;

        var incomingIds = workout.WorkoutExercises
            .Where(x => x.WorkoutExerciseId > 0)
            .Select(x => x.WorkoutExerciseId)
            .ToHashSet();

        var toRemove = existingWorkout.WorkoutExercises
            .Where(x => !incomingIds.Contains(x.WorkoutExerciseId))
            .ToList();

        _context.WorkoutExercises.RemoveRange(toRemove);

        foreach (var incomingExercise in workout.WorkoutExercises)
        {
            var existingExercise = existingWorkout.WorkoutExercises
                .FirstOrDefault(x => x.WorkoutExerciseId == incomingExercise.WorkoutExerciseId);

            if (existingExercise is not null)
            {
                existingExercise.ExerciseId = incomingExercise.ExerciseId;
                existingExercise.Sets = incomingExercise.Sets;
                existingExercise.Reps = incomingExercise.Reps;
                existingExercise.Order = incomingExercise.Order;
                existingExercise.Duration = incomingExercise.Duration;
                existingExercise.Weight = incomingExercise.Weight;
                existingExercise.Notes = incomingExercise.Notes;
            }
            else
            {
                existingWorkout.WorkoutExercises.Add(new WorkoutExercise
                {
                    ExerciseId = incomingExercise.ExerciseId,
                    Sets = incomingExercise.Sets,
                    Reps = incomingExercise.Reps,
                    Order = incomingExercise.Order,
                    Duration = incomingExercise.Duration,
                    Weight = incomingExercise.Weight,
                    Notes = incomingExercise.Notes
                });
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var workout = await _context.Workouts
            .Include(w => w.WorkoutExercises)
            .FirstOrDefaultAsync(w => w.WorkoutId == id);

        if (workout is null)
            throw new InvalidOperationException($"Workout with id {id} was not found.");

        _context.WorkoutExercises.RemoveRange(workout.WorkoutExercises);
        _context.Workouts.Remove(workout);

        await _context.SaveChangesAsync();
    }
}