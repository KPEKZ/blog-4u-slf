using Blog4uSlf.Application.Services;
using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Domain.Models.Posts;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Blog4uSlf.Application.Exceptions.Posts;

namespace Blog4uSlf.Tests.Unit.Services;

public class PostServiceTests
{
  private readonly Mock<ILogger<PostService>> _loggerMock = new();
  private readonly Mock<IPostRepository> _postRepositoryMock = new();
  private readonly IPostService _postService;

  public PostServiceTests()
  {
    _postService = new PostService(_postRepositoryMock.Object, _loggerMock.Object);
  }

  [Fact]
  public async Task CreateAsync_ShouldThrow_WhenSlugExists()
  {
    // Arrange
    var post = new Post { Title = "Test", Slug = "test" };

    _postRepositoryMock
      .Setup(x => x.SlugExistsAsync(post.Slug, default))
      .ReturnsAsync(true);

    // Act
    var act = async () => await _postService.CreateAsync(post, default);

    // Assert
    await act.Should()
      .ThrowAsync<PostDuplicateSlugException>()
      .WithMessage($"Post with slug '{post.Slug}' already exists.");
  }

  [Theory]
  [InlineData("Test", "Content", "test")]
  [InlineData("Test 2", "Content 2", null)]
  [InlineData("Test 3", "Content 3", "test-3")]
  public async Task CreateAsync_ShouldCreatePost(string title, string content, string? slug)
  {
    // Arrange
    var post = new Post { Title = title, Content = content, Slug = slug };

    _postRepositoryMock
      .Setup(x => x.AddAsync(It.IsAny<Post>(), default))
      .ReturnsAsync((Post p, CancellationToken _) => p);

    // Act
    var result = await _postService.CreateAsync(post, default);

    // Assert
    result.Should().NotBeNull();
    result.Title.Should().Be(title);
    result.Content.Should().Be(content);
    result.Slug.Should().Be(slug);
  }
}
