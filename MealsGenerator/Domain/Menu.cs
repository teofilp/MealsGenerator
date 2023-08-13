namespace MealsGenerator.Domain;

public class Menu
{
    public string Name { get; set; }
    public string Description { get; set; }
    public MenuCategory MenuCategory { get; set; }

    public List<Meal> Meals { get; set; }    
}