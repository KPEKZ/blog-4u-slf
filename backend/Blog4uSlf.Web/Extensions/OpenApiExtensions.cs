using Microsoft.OpenApi.Models;

namespace Blog4uSlf.Web.Extensions;

public static class OpenApiExtensions
{
  public static IServiceCollection AddOpenApiWithSwagger(this IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });
      c.EnableAnnotations();
      c.UseAllOfToExtendReferenceSchemas();
    });

    return services;
  }

  public static IApplicationBuilder UseOpenApiWithSwaggerUi(this IApplicationBuilder app)
  {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
    });

    return app;
  }
}
