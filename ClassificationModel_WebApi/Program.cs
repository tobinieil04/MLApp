// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ClassificationModel_WebApi;

// Configure app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<ClassificationModel.ModelInput, ClassificationModel.ModelOutput>()
    .FromFile("ClassificationModel.zip");
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Description = "Docs for my API", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// Define prediction route & handler
app.MapPost("/predict",
    async (PredictionEnginePool<ClassificationModel.ModelInput, ClassificationModel.ModelOutput> predictionEnginePool, string imagePath) =>
    {
        var input = new ClassificationModel.ModelInput()
        {
            ImageSource = File.ReadAllBytes(imagePath),
        };

        return await Task.FromResult(predictionEnginePool.Predict(input));
    });

// Run app
app.Run();
