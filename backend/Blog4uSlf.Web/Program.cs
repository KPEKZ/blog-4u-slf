using Blog4uSlf.Infrastructure;
using Blog4uSlf.Web.Extensions;
using Blog4uSlf.Web.Mapping;
using Blog4uSlf.Web.Middlewares;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Logging
Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Host.UseSerilog();


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
builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
{
  policy.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ErrorHandlingMiddleware>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// OpenAPI/Swagger
builder.Services.AddOpenApiWithSwagger();

var app = builder.Build();

app.UseSerilogRequestLogging(options =>
{
  options.MessageTemplate =
      "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

  options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
  {
    diagnosticContext.Set("UserAgent", httpContext.Request.Headers["User-Agent"].ToString());
    diagnosticContext.Set("Host", httpContext.Request.Host.Value);
  };
});

app.UseExceptionHandler();
app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseOpenApiWithSwaggerUi();


app.MapControllers();

try
{
  Log.Information("🚀 Starting web application");
  app.Run();
}
catch (Exception ex)
{
  Log.Fatal(ex, "❌ Application terminated unexpectedly");
}
finally
{
  Log.CloseAndFlush();
}

public partial class Program { }
