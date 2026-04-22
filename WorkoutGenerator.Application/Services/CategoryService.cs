using WorkoutGenerator.Application.DTOs.Categories;
using WorkoutGenerator.Application.Interfaces.Repositories;
using WorkoutGenerator.Application.Interfaces.Services;
using WorkoutGenerator.Domain;

namespace WorkoutGenerator.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(c => new CategoryDto
        {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName
        }).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null) return null;

        return new CategoryDto
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName
        };
    }

    public async Task<CategoryDto> AddAsync(CategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName
        };

        var created = await _categoryRepository.AddAsync(category);

        return new CategoryDto
        {
            CategoryId = created.CategoryId,
            CategoryName = created.CategoryName
        };
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var category = new Category
        {
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName
        };

        await _categoryRepository.UpdateAsync(category);
    }

    public Task DeleteAsync(int id)
        => _categoryRepository.DeleteAsync(id);
}