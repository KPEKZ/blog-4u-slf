using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Application.Services;
using Blog4uSlf.Infrastructure.Persistence;
using Blog4uSlf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog4uSlf.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<IPostService, PostService>();

    return services;
  }
}
