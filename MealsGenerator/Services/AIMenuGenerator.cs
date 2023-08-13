using System.Text.Json;
using MealsGenerator.Domain;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace MealsGenerator.Services;

public class AIMenuGenerator : IMenuGenerator
{
    private readonly IOpenAIService _openAiService;
    private readonly ILogger<AIMenuGenerator> _logger;

    public AIMenuGenerator(IServiceProvider serviceProvider, ILogger<AIMenuGenerator> logger)
    {
        _openAiService = serviceProvider.GetRequiredService<IOpenAIService>();
        _logger = logger;
    }

    public async Task<Menu> GenerateDailyMenu(MenuCategory category)
    {
        var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
            {
                ChatMessage.FromSystem(Constants.SystemPrompt),
                ChatMessage.FromUser(Constants.GetUserPrompt(category))
            },
            Model = Models.Gpt_3_5_Turbo,
            MaxTokens = 2048,
            N = 1,
            PresencePenalty = 1.5f,
        });

        if (completionResult.Successful)
        {
            var result = completionResult.Choices.First().Message.Content;
            var item = JsonSerializer.Deserialize<Menu>(result);

            return item;
        }

        _logger.LogWarning("Could not create completion, exception: {exception}", completionResult.Error.Message);
        return null;
    }
}