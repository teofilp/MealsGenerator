namespace MealsGenerator.Domain;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public MealType MealType  { get; set; }
    public Recipe? Recipe { get; set; }
}