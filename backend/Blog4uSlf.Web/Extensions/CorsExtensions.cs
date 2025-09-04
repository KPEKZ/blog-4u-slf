namespace Blog4uSlf.Web.Extensions;

public static class CorsExtensions
{
  /// <summary>
  /// Adds a CORS policy to the specified <see cref="IServiceCollection"/>.
  /// </summary>
  /// <param name="services">The service collection to add the CORS policy to.</param>
  /// <param name="policyName">The name of the CORS policy to add.</param>
  /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
  public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policyName)
  {
    services.AddCors(options =>
    {
      options.AddPolicy(policyName,
        builder => builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
    });

    return services;
  }

}
