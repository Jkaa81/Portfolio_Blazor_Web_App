using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Application.Interfaces.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetAllAsync();
    Task<Workout?> GetByIdAsync(int id);
    Task<Workout> AddAsync(Workout workout);
    Task UpdateAsync(Workout workout);
    Task DeleteAsync(int id);
}