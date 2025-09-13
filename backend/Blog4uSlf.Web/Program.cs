using Blog4uSlf.Infrastructure;
using Blog4uSlf.Web.Extensions;
using Blog4uSlf.Web.Mapping;
using Blog4uSlf.Web.Middlewares;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Mapster
MappingConfig.Register();
builder.Services.AddMapster();
builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
  options.JsonSerializerOptions.WriteIndented = builder.Environment.IsDevelopment();
});

// Validation
builder.Services.AddFluentValidation();
builder.Services.AddFluentValidationAutoValidation();

// Infrastructure (EF Core, репозитории)
builder.Services.AddInfrastructure(builder.Configuration);

// Cors
builder.Services.AddCorsPolicy("AllowAllOrigins");

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ErrorHandlingMiddleware>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// OpenAPI/Swagger
builder.Services.AddOpenApiWithSwagger();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseOpenApiWithSwaggerUi();

app.MapControllers();

app.Run();
