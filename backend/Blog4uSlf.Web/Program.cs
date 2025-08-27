using Blog4uSlf.Web.Extensions;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Mapster

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// OpenAPI/Swagger
builder.Services.AddOpenApiWithSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseOpenApiWithSwaggerUi();

app.Run();
