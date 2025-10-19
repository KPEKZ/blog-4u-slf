using System.Net;
using System.Net.Http.Json;
using Blog4uSlf.Application.Dto.Posts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Blog4uSlf.Tests.Integration.Controllers;

public class PostControllerTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task GetLatest_ShouldReturnOk()
  {
    // Arrange
    var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/posts");

    // Act
    var response = await _client.SendAsync(request);

    // Assert
    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

    var posts = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<PostDto>>();
    posts.Should().NotBeNull();
  }

  [Theory]
  [InlineData("", "Content")]
  [InlineData("Title", "")]
  [InlineData("", "")]
  [InlineData(null, "Content")]
  [InlineData("Title", null)]
  [InlineData(null, null)]
  public async Task CreateAsync_ShouldThrow_WhenTitleOrContentIsEmpty(string? title, string? content)
  {
    // Arrange
    var post = new PostCreateDto { Title = title, Content = content };

    // Act
    var response = await _client.PostAsJsonAsync("/api/v1/posts", post);

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
  }

}
