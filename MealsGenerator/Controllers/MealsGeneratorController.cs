using MealsGenerator.Domain;
using MealsGenerator.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MealsGenerator.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MealsGeneratorController
{
    private readonly IMenuGenerator _menuGenerator;

    public MealsGeneratorController(IMenuGenerator menuGenerator)
    {
        _menuGenerator = menuGenerator;
    }

    [HttpGet]
    public async Task<IActionResult> GenerateMenu([FromQuery] MenuCategory category)
    {
        var menu = await _menuGenerator.GenerateDailyMenu(category);

        return new OkObjectResult(menu);
    }
}