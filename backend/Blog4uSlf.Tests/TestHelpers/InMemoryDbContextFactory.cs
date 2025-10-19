using Blog4uSlf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog4uSlf.Tests.TestHelpers;

public static class InMemoryDbContextFactory
{
  public static BlogDbContext Create()
  {
    var options = new DbContextOptionsBuilder<BlogDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

    var context = new BlogDbContext(options);
    context.Database.EnsureCreated();

    return context;
  }
}
