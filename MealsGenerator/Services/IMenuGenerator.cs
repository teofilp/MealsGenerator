using MealsGenerator.Domain;

namespace MealsGenerator.Services;

public interface IMenuGenerator
{
    Task<Menu> GenerateDailyMenu(MenuCategory category);
}