using WorkoutGenerator.Application.DTOs.Workouts;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Application.Interfaces.Services;
using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Application.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<List<WorkoutDto>> GetAllAsync()
    {
        var workouts = await _workoutRepository.GetAllAsync();
        return workouts.Select(MapToDto).ToList();
    }

    public async Task<WorkoutDto?> GetByIdAsync(int id)
    {
        var workout = await _workoutRepository.GetByIdAsync(id);
        return workout is null ? null : MapToDto(workout);
    }

    public async Task<WorkoutDto> AddAsync(CreateWorkoutDto dto)
    {
        var workout = new Workout
        {
            CoachId = dto.CoachId,
            CustomerId = dto.CustomerId,
            WorkoutTitle = dto.WorkoutTitle,
            WorkoutDescription = dto.WorkoutDescription,
            IsTemplate = dto.IsTemplate,
            IsArchived = dto.IsArchived,
            WorkoutExercises = dto.WorkoutExercises.Select(x => new WorkoutExercise
            {
                ExerciseId = x.ExerciseId,
                Sets = x.Sets,
                Reps = x.Reps,
                Order = x.Order,
                Duration = x.Duration,
                Weight = x.Weight,
                Notes = x.Notes
            }).ToList()
        };

        var created = await _workoutRepository.AddAsync(workout);
        var fullWorkout = await _workoutRepository.GetByIdAsync(created.WorkoutId);

        return MapToDto(fullWorkout!);
    }

    public async Task UpdateAsync(UpdateWorkoutDto dto)
    {
        var workout = new Workout
        {
            WorkoutId = dto.WorkoutId,
            CoachId = dto.CoachId,
            CustomerId = dto.CustomerId,
            WorkoutTitle = dto.WorkoutTitle,
            WorkoutDescription = dto.WorkoutDescription,
            IsTemplate = dto.IsTemplate,
            IsArchived = dto.IsArchived,
            WorkoutExercises = dto.WorkoutExercises.Select(x => new WorkoutExercise
            {
                WorkoutExerciseId = x.WorkoutExerciseId ?? 0,
                ExerciseId = x.ExerciseId,
                Sets = x.Sets,
                Reps = x.Reps,
                Order = x.Order,
                Duration = x.Duration,
                Weight = x.Weight,
                Notes = x.Notes
            }).ToList()
        };

        await _workoutRepository.UpdateAsync(workout);
    }

    public Task DeleteAsync(int id)
        => _workoutRepository.DeleteAsync(id);

    private static WorkoutDto MapToDto(Workout workout)
    {
        return new WorkoutDto
        {
            WorkoutId = workout.WorkoutId,
            CoachId = workout.CoachId,
            CoachName = workout.Coach?.Name ?? string.Empty,
            CustomerId = workout.CustomerId,
            CustomerName = workout.Customer?.Name,
            WorkoutTitle = workout.WorkoutTitle,
            WorkoutDescription = workout.WorkoutDescription,
            IsTemplate = workout.IsTemplate,
            IsArchived = workout.IsArchived,
            WorkoutExercises = workout.WorkoutExercises
                .OrderBy(x => x.Order)
                .Select(x => new WorkoutExerciseDto
                {
                    WorkoutExerciseId = x.WorkoutExerciseId,
                    ExerciseId = x.ExerciseId,
                    ExerciseName = x.Exercise?.ExerciseName ?? string.Empty,
                    Sets = x.Sets,
                    Reps = x.Reps,
                    Order = x.Order,
                    Duration = x.Duration,
                    Weight = x.Weight,
                    Notes = x.Notes
                }).ToList()
        };
    }
}