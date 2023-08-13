using System.Text.Json.Serialization;

namespace MealsGenerator.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MealType
{
    Breakfast = 1,
    Lunch = 2,
    Dinner = 3,
    Dessert = 4,
    Snack = 5
}