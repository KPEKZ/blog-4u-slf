
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Application.Dto.Posts;
using Blog4uSlf.Domain.Entities.Posts;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Blog4uSlf.Web.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController(IPostService postService) : ControllerBase
{
  private readonly IPostService _postService = postService;

  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
  {
    var post = await _postService.GetByIdAsync(id, ct);
    return post is null ? NotFound() : Ok(post.Adapt<PostDto>());
  }


  [HttpGet]
  public async Task<IActionResult> GetLatests([FromQuery] int? take, [FromQuery] int? skip, CancellationToken ct)
  {
    var posts = await _postService.GetLatestsAsync(take ?? 50, skip ?? 0, ct);
    return Ok(posts.Adapt<IReadOnlyList<PostDto>>());
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] PostCreateDto postDto, CancellationToken ct)
  {
    var post = postDto.Adapt<PostCreate>();
    var created = await _postService.CreateAsync(post, ct);
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.Adapt<PostDto>());
  }

  [HttpPut("{id:guid}")]
  public async Task<IActionResult> UpdatePostById([FromRoute] Guid id, [FromBody] PostUpdateDto postDto, CancellationToken ct)
  {
    var post = postDto.Adapt<PostUpdate>();
    var updated = await _postService.UpdateByIdAsync(id, post, ct);
    return Ok(updated.Adapt<PostDto>());
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePostById([FromRoute] Guid id, CancellationToken ct)
  {
    {
      await _postService.DeleteByIdAsync(id, ct);
      return NoContent();
    }
  }

}
