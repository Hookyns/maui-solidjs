using SolidHybridApp.Api.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApiConfiguration();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();