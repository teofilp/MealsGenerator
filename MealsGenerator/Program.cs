using MealsGenerator.Services;
using OpenAI.Extensions;
using OpenAI.ObjectModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

builder.Services.AddTransient<IMenuGenerator, AIMenuGenerator>();

builder.Services.AddOpenAIService(settings =>
{
    settings.ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY") ?? string.Empty;
    settings.DefaultModelId = Models.Davinci;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();