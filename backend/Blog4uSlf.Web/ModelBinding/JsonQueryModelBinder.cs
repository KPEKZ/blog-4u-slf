using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog4uSlf.Web.ModelBinding;

public class JsonQueryModelBinder(ILogger<JsonQueryModelBinder> logger): IModelBinder
{
  private readonly ILogger<JsonQueryModelBinder> _logger = logger;

  public Task BindModelAsync(ModelBindingContext context)
  {
    var value = context.ValueProvider.GetValue(context.ModelName).FirstValue;

    _logger.LogInformation($"Try parsing a query parameter: {value}");

    if (string.IsNullOrEmpty(value))
    {
      context.Result = ModelBindingResult.Success(Activator.CreateInstance(context.ModelType));
      return Task.CompletedTask;
    }

    try
    {
      var elementType = context.ModelType.IsGenericType && context.ModelType.GetGenericTypeDefinition() == typeof(List<>)
        ? context.ModelType
        : typeof(List<>).MakeGenericType(context.ModelType);

      var result = JsonSerializer.Deserialize(
        value,
        elementType,
        new JsonSerializerOptions
        {
          PropertyNameCaseInsensitive = true,
          Converters = { new JsonStringEnumConverter() }
        });

      context.Result = ModelBindingResult.Success(result);
    }
    catch (JsonException e)
    {
      _logger.LogError(e, e.Message);
      context.ModelState.AddModelError(context.ModelName,"Invalid JSON format");
      context.Result = ModelBindingResult.Failed();
    }

    return Task.CompletedTask;
  }
}
