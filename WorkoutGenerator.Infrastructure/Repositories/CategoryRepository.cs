using Microsoft.EntityFrameworkCore;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Domain;
using WorkoutGenerator.Infrastructure.Data;

namespace WorkoutGenerator.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WorkoutContext _context;

    public CategoryRepository(WorkoutContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    public async Task<Category> AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task UpdateAsync(Category category)
    {
        var existingCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);

        if (existingCategory is null)
            throw new InvalidOperationException($"Category with id {category.CategoryId} was not found.");

        existingCategory.CategoryName = category.CategoryName;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category is null)
            throw new InvalidOperationException($"Category with id {id} was not found.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}