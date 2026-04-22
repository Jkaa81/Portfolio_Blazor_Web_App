using WorkoutGenerator.Application.DTOs.Workouts;

namespace WorkoutGenerator.Application.Interfaces.Services;

public interface IWorkoutService
{
    Task<List<WorkoutDto>> GetAllAsync();
    Task<WorkoutDto?> GetByIdAsync(int id);
    Task<WorkoutDto> AddAsync(CreateWorkoutDto dto);
    Task UpdateAsync(UpdateWorkoutDto dto);
    Task DeleteAsync(int id);
}