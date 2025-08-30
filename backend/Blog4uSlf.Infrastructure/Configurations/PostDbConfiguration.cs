namespace Blog4uSlf.Infrastructure.Configurations;

using Blog4uSlf.Domain.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class PostDbConfiguration : IEntityTypeConfiguration<Post>
{
  public void Configure(EntityTypeBuilder<Post> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
    builder.Property(e => e.Content).IsRequired();
    builder.Property(e => e.CreatedAt).IsRequired();
    builder.Property(e => e.UpdatedAt).IsRequired();
    builder.Property(e => e.Slug).IsRequired().HasMaxLength(200);
    builder.HasIndex(e => e.Slug).IsUnique();
  }
}
