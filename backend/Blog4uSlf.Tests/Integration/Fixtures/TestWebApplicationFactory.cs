using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Blog4uSlf.Infrastructure.Persistence;

namespace Blog4uSlf.Tests.Integration.Fixtures;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BlogDbContext>));

      if (descriptor != null)
      {
        services.Remove(descriptor);
      }

      services.AddDbContext<BlogDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
    });
  }
}
