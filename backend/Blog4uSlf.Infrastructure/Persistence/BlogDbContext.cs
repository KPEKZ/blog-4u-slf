using Blog4uSlf.Domain.Entities.Posts;
using Blog4uSlf.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog4uSlf.Infrastructure.Persistence;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
  public DbSet<Post> Posts { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new PostDbConfiguration());
  }
}
