using System.Text.Json.Serialization;

namespace MealsGenerator.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MenuCategory
{
    Fitness = 1,
    FoodLover = 2,
    Gym = 3,
    Vegetarian = 4
}