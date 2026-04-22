using Microsoft.Extensions.DependencyInjection;
using WorkoutGenerator.Application.Interfaces.Services;
using WorkoutGenerator.Application.Services;

namespace WorkoutGenerator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IDifficultyLevelService, DifficultyLevelService>();
        return services;
    }
}